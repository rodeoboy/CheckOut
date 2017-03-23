# CheckOut

# Limitations
1. Currently there is no validation on the file uploads. If file format is not valid an error message is displayed to the user. 
2. Products not found in promotion upload or check out are not added

# Design Choices
1. Discount calculation is done using a rule engine pattern to allow extending the type of calculations performed on item. Currently only Sale Price is implemented.
2. Client, domain and service classes should be implemented in their own components to better inforce encapsulation.

# User Documentation

Loading Product Catalog

1. Create a text file with product items. One item per line with product name the price seperated by comma. For example:
  Apple, 2.00
  Orange, 1.50
  Banana, 1.00
2. Run the application and select "Add products" from the menu.
3. Type in the path to the file created above.

Loading Product Promotions

1. Create a text file with product promotion items. One item per line with promotion type (currently only SalePrice is supported), the sale price, expiry date (in dd/mm/yyyy format) and product name seperated by comma. For example:
  SalePrice, 1.00, 11/11/2017, Apple
  SalePrice, 1.00, 11/11/2017, Banana
2. Reun the application and select "Add promotions" from the menu.
3. Type in the path to the file created above.
NOTE: Promotion products not found in the product catalog will not be added.

Check Out Cart

1. Create a text file with product items. One item per line with product name the price seperated by comma. For example:
  Apple
  Orange
  Banana
2. Reun the application and select "Check out items" from the menu.
3. Type in the path to the file created above.

# Sample Files
There are three sample file in the root of the repository:
1. CheckOut.txt - a sample check out file
2. Products.txt - a sample product catalog upload file
3. ProductPromotions.txt - a sample promotions upload file

In debug mode each file can be used by relative path. For example: "../../../CheckOut.txt"
