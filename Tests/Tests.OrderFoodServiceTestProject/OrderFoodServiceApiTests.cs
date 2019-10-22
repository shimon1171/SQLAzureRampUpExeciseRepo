using DalApi;
using OrderFoodService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using FakeItEasy;
using Shouldly;
namespace Tests.OrderFoodServiceTestProject
{
    public class OrderFoodServiceApiTests
    {
        private  DateTime DEFAULT_TIME = new DateTime(1985, 9, 17);

        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IDal _dal;
        private readonly IOrderFoodServiceApi _service;

        public OrderFoodServiceApiTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            _dal = A.Fake<IDal>();
            A.CallTo(() => _dal.Init()).Returns(true);
            _service = new OrderFoodServiceApi(_dal);
        }


        [Fact]
        public void GetOrdersByCompanyAndDay_companyNameIsNull_returnNull()
        {
            // arrange
            A.CallTo(() => _dal.GetOrdersByCompanyAndDay(A<string>.Ignored, A<DateTime>.Ignored)).Returns(new List<string>());
            string companyName = null;
            DateTime time = DEFAULT_TIME;

            // act
            var res = _service.GetOrdersByCompanyAndDay(companyName, time);

            // assert
            res.ShouldBeNull();
        }

        
        [Theory]
        [InlineData(null,"Microsoft","Japnika","Description_09: 15:2019")]
        [InlineData("Yarden Kristal",null,"Japnika","Description_09: 15:2019")]
        [InlineData("Yarden Kristal","Microsoft",null,"Description_09: 15:2019")]
        [InlineData("Yarden Kristal","Microsoft","Japnika",null)]
        public void Order_InputIsNull_returnMinus1(
            string userName, 
            string companyName, 
            string restaurantName, 
            string description )
        {
            // arrange
            A.CallTo(() => _dal.Order(A<string>.Ignored, A<string>.Ignored, A<string>.Ignored, A<string>.Ignored, A<DateTime>.Ignored)).Returns(20);

            // act
            var res = _service.Order(userName, companyName, restaurantName, description, DEFAULT_TIME);

            // assert
            res.ShouldBe(-1);
        }




    }
}
