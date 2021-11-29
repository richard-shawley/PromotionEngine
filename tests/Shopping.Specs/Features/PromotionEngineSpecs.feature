Feature: PromotionEngineSpecs

This feature is test the promotion engine behaviour against the scenarios outlined in the brief

Background:
	Given product 'A' costs '50.0'
	And product 'B' costs '30.0'
	And product 'C' costs '20.0'
	And product 'D' costs '15.0'
	And there is a promotion for '3' of product 'A' costing '130.0'
	And there is a promotion for '2' of product 'B' costing '45.0'
	And there is a promotion for products 'C, D' costing '30.0'

@promotionEngine
Scenario: A
	Given the cart contains '1' of product 'A'
	And the cart contains '1' of product 'B'
	And the cart contains '1' of product 'C'
	When the customer checks out
	Then the calculated total is '100.0'

@promotionEngine
Scenario: B
	Given the cart contains '5' of product 'A'
	And the cart contains '5' of product 'B'
	And the cart contains '1' of product 'C'
	When the customer checks out
	Then the calculated total is '370.0'

@promotionEngine
Scenario: C
	Given the cart contains '3' of product 'A'
	And the cart contains '5' of product 'B'
	And the cart contains '1' of product 'C'
	And the cart contains '1' of product 'D'
	When the customer checks out
	Then the calculated total is '280.0'

@promotionEngine
Scenario: BigCart
	Given the cart contains '10' of product 'A'
	And the cart contains '10' of product 'B'
	And the cart contains '10' of product 'C'
	And the cart contains '15' of product 'D'
	When the customer checks out
	Then the calculated total is '1040.0'