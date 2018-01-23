Feature: Basket_Feature
	In order to add items in the basket
	As a user
	I want to have 'Basket Feature' feature
	So that I can add items in the basket using products offered

Scenario: Check Basket state without action with basket
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	And I click CART button on the Header Page

	Then I see Basket Page
	And I see notification message "Your shopping cart is empty." on the "Basket Page"

Scenario: Check Basket state when user added item in the Basket and logout of the system
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	And I click CART button on the Header Page

	Then I see Basket Page
	And I delete items from the basket if they exist

	When I click Log in button on the Header Page
	And I set following parameters on Login popup
		| Field         | Value                   |
		| Email Address | autestomation@gmail.com |
		| Password      | 4sep98MPcalifUSA        |
	And I click Log in button on Login popup

	Then I see element My Account on the Header Page
	And I see that user "Test" is logged in
	And I see Basket Page

	When I click Continue Shopping button on Basket Page
	Then I see Main page

	When I click Create Business Cards button on Main Page
	And I click Get Started button on "Business Cards" Product page
	And I click Customize button on "Business Cards" Template page
	And I click Next button on "Business Cards" Builder page
	And I click Approve button on "Business Cards" Builder page

	Then I wait for 50 seconds for "Approve Order Page" is load
	When I click Continue Order button on "Business Cards" Approve Order Page

	Then I see Basket Page
	And I wait for 10 seconds for "500 Double Sided Business Cards" is load
	And I see following product on the Cart
		| Name                            | Quantity Price | Material Price | Item Subtotal |
		| 500 Double Sided Business Cards | $39.95         | $0.00          | $25.95        |
	And I see Basket contains "1" elements
	
	When I click Back to shopping button on Basket Page
	Then I see Main page

	When I click Create Postcards button on Main Page
	And I click Get Started button on "Postcards" Product page
	And I click Customize button on "Postcards" Template page
	And I click Next button on "Postcards" Builder page
	And I click Approve button on "Postcards" Builder page
	And I click Skip button on "Postcards" Mailing List Page

	Then I wait for 50 seconds for "Approve Order Page" is load
	When I click Continue Order button on "Postcards" Approve Order Page

	Then I see Basket Page
	And I wait for 10 seconds for "500 Double Sided Business Cards" is load
	And I wait for 10 seconds for "1000 Double Sided" is load
	And I see following product on the Cart
		| Name                            | Quantity Price | Material Price | Item Subtotal |
		| 500 Double Sided Business Cards | $39.95         | $0.00          | $25.95        |
		| 1000 Double Sided               | $126.45        | $0.00          | $84.65        |
	And I see Basket contains "2" elements

	When I click Log out button on the Header Page
	Then I see Main page
	And I see that user is not logged in

	When I click CART button on the Header Page
	Then I see Basket Page
	And I wait for 10 seconds for "500 Double Sided Business Cards" is load
	And I wait for 10 seconds for "1000 Double Sided" is load
	And I see following product on the Cart
		| Name                            | Quantity Price | Material Price | Item Subtotal |
		| 500 Double Sided Business Cards | $39.95         | $0.00          | $29.35        |
		| 1000 Double Sided               | $126.45        | $0.00          | $98.95        |
	And I see Basket contains "2" elements

Scenario: Check Basket state when login user added item in the basket, logout, remove item from basket and login
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	And I click CART button on the Header Page

	Then I see Basket Page
	And I delete items from the basket if they exist

	When I click Log in button on the Header Page
	And I set following parameters on Login popup
		| Field         | Value                   |
		| Email Address | autestomation@gmail.com |
		| Password      | 4sep98MPcalifUSA        |
	And I click Log in button on Login popup

	Then I see element My Account on the Header Page
	And I see that user "Test" is logged in
	And I see Basket Page

	When I click Continue Shopping button on Basket Page
	Then I see Main page
	
	When I click Create Business Cards button on Main Page
	And I click Get Started button on "Business Cards" Product page
	And I click Customize button on "Business Cards" Template page
	And I click Next button on "Business Cards" Builder page
	And I click Approve button on "Business Cards" Builder page

	Then I wait for 50 seconds for "Approve Order Page" is load
	When I click Continue Order button on "Business Cards" Approve Order Page

	Then I see Basket Page
	And I wait for 10 seconds for "500 Double Sided Business Cards" is load
	And I see following product on the Cart
		| Name                            | Quantity Price | Material Price | Item Subtotal |
		| 500 Double Sided Business Cards | $39.95         | $0.00          | $25.95        |
	And I see the following properties in the shopping cart
		| Property             | Value  |
		| Total price          | $26.95 |
	And I see Basket contains "1" elements
	
	When I click Back to shopping button on Basket Page
	Then I see Main page

	When I click Create Postcards button on Main Page
	And I click Get Started button on "Postcards" Product page
	And I click Customize button on "Postcards" Template page
	And I click Next button on "Postcards" Builder page
	And I click Approve button on "Postcards" Builder page
	And I click Skip button on "Postcards" Mailing List Page

	Then I wait for 50 seconds for "Approve Order Page" is load
	When I click Continue Order button on "Postcards" Approve Order Page

	Then I see Basket Page
	And I wait for 10 seconds for "500 Double Sided Business Cards" is load
	And I wait for 10 seconds for "1000 Double Sided" is load
	And I see following product on the Cart
		| Name                            | Quantity Price | Material Price | Item Subtotal |
		| 500 Double Sided Business Cards | $39.95         | $0.00          | $25.95        |
		| 1000 Double Sided               | $126.45        | $0.00          | $84.65        |
	And I see the following properties in the shopping cart
		| Property             | Value  |
		| Total price          | $112.60 |
	And I see Basket contains "2" elements

	When I click Log out button on the Header Page
	Then I see Main page
	And I see that user is not logged in

	When I click CART button on the Header Page
	Then I see Basket Page
	And I wait for 10 seconds for "500 Double Sided Business Cards" is load
	And I wait for 10 seconds for "1000 Double Sided" is load
	And I see following product on the Cart
		| Name                            | Quantity Price | Material Price | Item Subtotal |
		| 500 Double Sided Business Cards | $39.95         | $0.00          | $29.35        |
		| 1000 Double Sided               | $126.45        | $0.00          | $98.95        |
	And I see the following properties in the shopping cart
		| Property    | Value   |
		| Total price | $130.30 |
	And I see Basket contains "2" elements

	When I remove "500 Double Sided Business Cards" item from basket
	Then I see Basket Page
	Then I wait for 10 seconds
	Then I don't see following product on the Cart
		| Name                            | Quantity Price | Material Price | Item Subtotal |
		| 500 Double Sided Business Cards | $39.95         | $0.00          | $29.35        |
	And I see the following properties in the shopping cart
		| Property             | Value  |
		| Total price          | $99.95 |
	And I see Basket contains "1" elements

	When I remove "1000 Double Sided" item from basket
	Then I see Basket Page
	Then I wait for 10 seconds
	Then I don't see following product on the Cart
		| Name                            | Quantity Price | Material Price | Item Subtotal |
		| 500 Double Sided Business Cards | $39.95         | $0.00          | $29.35        |
		| 1000 Double Sided               | $126.45        | $0.00          | $98.95        |
	And I see Basket contains "0" elements

	When I click Log in button on the Header Page
	And I set following parameters on Login popup
		| Field         | Value                   |
		| Email Address | autestomation@gmail.com |
		| Password      | 4sep98MPcalifUSA        |
	And I click Log in button on Login popup

	Then I see that user "Test" is logged in
	And I see Basket Page
	And I see notification message "Your shopping cart is empty." on the "Basket Page"

Scenario: Check Basket state after decline option "Professional File Review"
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	And I click CART button on the Header Page

	When I click Continue Shopping button on Basket Page
	Then I see Main page
	
	When I click Create Business Cards button on Main Page
	And I click Get Started button on "Business Cards" Product page
	And I click Customize button on "Business Cards" Template page
	And I click Next button on "Business Cards" Builder page
	And I click Approve button on "Business Cards" Builder page

	Then I wait for 50 seconds for "Approve Order Page" is load
	When I click Continue Order button on "Business Cards" Approve Order Page

	Then I see Basket Page
	And I wait for 10 seconds for "500 Double Sided Business Cards" is load
	And I see following product on the Cart
		| Name                            | Quantity Price                  | Item Subtotal  |
		| 500 Double Sided Business Cards | $39.95                          | $29.35         |
	And I see the following properties in the shopping cart
		| Property             | Value  |
		| Total price          | $30.35 |
	And I see Basket contains "1" elements
	When I click Professional File Review Decline button on Basket Page

	Then I wait for 10 seconds for "Order Summery Block" is load
	And I see the following properties in the shopping cart
		| Property             | Value  |
		| Order SubTotal price | $39.95 |
		| Total price          | $29.35 |

Scenario Template: Check Basket state after change product parameters on the basket
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	And I click CART button on the Header Page

	When I click Continue Shopping button on Basket Page
	Then I see Main page
	
	When I click Create Business Cards button on Main Page
	And I click Get Started button on "Business Cards" Product page
	And I click Customize button on "Business Cards" Template page
	And I click Next button on "Business Cards" Builder page
	And I click Approve button on "Business Cards" Builder page

	Then I wait for 50 seconds for "Approve Order Page" is load
	When I click Continue Order button on "Business Cards" Approve Order Page

	Then I see Basket Page
	And I wait for 10 seconds for "500 Double Sided Business Cards" is load
	And I see following product on the Cart
		| Name                            | Quantity Price | Material Price | Item Subtotal |
		| 500 Double Sided Business Cards | $39.95         | $0.00          | $29.35        |
	And I see the following properties in the shopping cart
		| Property             | Value  |
		| Total price          | $30.35 |
	And I see Basket contains "1" elements
	
	When I click Property dropDownMenu and choose Value for the Product on Basket Page
		| Property   | Value    | Product                         |
		| <Property> | <Value>  | 500 Double Sided Business Cards |
	Then I wait for 10 seconds for "Order Summery Block" is load
	And I see the following properties in the shopping cart
		| Property                 | Value                       |
		| Order SubTotal price     | <Real Order Subtotal price> |
		| Professional File Review | $1.00                       |
		| Total price              | <Real Total price>          |

	Examples: 
		| Property | Value    | Price          | Real Order Subtotal price | Real Total price |
		| Quantity | 25       | Quantity Price | $7.15                     | $6.24            |
		| Material | Sandwich | Material Price | $363.15                   | $151.12          |

Scenario Template: Check Basket state after change shipping option
	When I open browser
	And I navigate to url "https://www.overnightprints.com"
	And I click CART button on the Header Page

	When I click Continue Shopping button on Basket Page
	Then I see Main page
	
	When I click Create Business Cards button on Main Page
	And I click Get Started button on "Business Cards" Product page
	And I click Customize button on "Business Cards" Template page
	And I click Next button on "Business Cards" Builder page
	And I click Approve button on "Business Cards" Builder page

	Then I wait for 50 seconds for "Approve Order Page" is load
	When I click Continue Order button on "Business Cards" Approve Order Page

	Then I see Basket Page
	And I wait for 10 seconds for "500 Double Sided Business Cards" is load
	And I see following product on the Cart
		| Name                            | Quantity Price | Material Price | Item Subtotal |
		| 500 Double Sided Business Cards | $39.95         | $0.00          | $29.35        |
	And I see the following properties in the shopping cart
		| Property             | Value  |
		| Total price          | $30.35 |
	And I see Basket contains "1" elements

	When I set Shipping Zip Code "99577" on the Basket Page
	And I click Apply Zip Code button on Basket Page

	Then I wait for 20 seconds for "Order Summery Block" is load
	When I click <Shipping description> button on Basket Page

	Then I wait for 15 seconds for "Order Summery Block" is load
	And I see the following properties in the shopping cart
		| Property                 | Value                 |
		| Order SubTotal price     | $39.95                |
		| Professional File Review | $1.00                 |
		| Total price              | <Real Total Price>    |
		| <Shipping Price Locator> | <Real Shipping Price> |

	Examples: 
		| Shipping description | Shipping Price Locator | Real Shipping Price | Real Total Price |
		| 2 Day Shipping       | 2 Day Shipping price   | $21.55              | $51.90           |
		| BITGIT               | Bit Git price          | $43.42              | $73.77           |