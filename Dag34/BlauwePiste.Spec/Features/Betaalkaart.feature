Feature: Betaalkaart
	
	
Scenario: Betaalkaart uitgeven
	Given naam is "Jonathan Bakker"
	And gewenst saldo is 15 euro
	When betaalkaart is aangemaakt
	Then de betaalkaart heeft de opgeven naam en saldo
	
Scenario: Betaalkaart saldo alleen afnemen
	Given gewenst saldo is 15 euro
	And betaalkaart is aangemaakt
	When saldo van 5 euro bijschrijven
	Then saldo blijft onveranderd