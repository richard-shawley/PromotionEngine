using System;
using System.Collections.Generic;
using Shopping.Specs.Context;
using TechTalk.SpecFlow;

namespace Shopping.Specs
{
    [Binding]
    public class PromotionEngineSpecsStepDefinitions
    {
        private readonly PromotionEngineContext _promotionEngineContext;

        private readonly ScenarioContext _scenarioContext;

        public PromotionEngineSpecsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"product '(.*)' costs '(.*)'")]
        public void GivenProductCosts(string sku, decimal price)
        {
            _scenarioContext.Pending();
        }

        [Given(@"there is a promotion for '(.*)' of product '(.*)' costing '(.*)'")]
        public void GivenThereIsAPromotionForOfProductCosting(int quantity, string sku, decimal price)
        {
            _scenarioContext.Pending();
        }

        [Given(@"there is a promotion for products '(.*)' costing '(.*)'")]
        public void GivenThereIsAPromotionForProductsCosting(string skuList, decimal price)
        {
            _scenarioContext.Pending();
        }

        [Given(@"the cart contains '(.*)' of product '(.*)'")]
        public void GivenTheCartContainsOfProduct(int quantity, string sku)
        {
            _scenarioContext.Pending();
        }

        [When(@"the promotion engine is triggered")]
        public void WhenThePromotionEngineIsTriggered()
        {
            _scenarioContext.Pending();
        }

        [Then(@"the calculated total is '(.*)'")]
        public void ThenTheCalculatedTotalIs(decimal calculatedTotal)
        {
            _scenarioContext.Pending();
        }
    }
}

