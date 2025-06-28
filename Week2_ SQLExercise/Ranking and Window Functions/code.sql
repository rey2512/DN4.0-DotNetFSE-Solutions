
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2),
    StockQuantity INT
);


INSERT INTO Products VALUES
(1, 'Ultra HD TV', 'Electronics', 899.99, 15),
(2, 'Wireless Headphones', 'Electronics', 199.99, 30),
(3, 'Smartphone', 'Electronics', 699.99, 25),
(4, 'Blender', 'Home Appliances', 79.99, 40),
(5, 'Coffee Maker', 'Home Appliances', 129.99, 35),
(6, 'Vacuum Cleaner', 'Home Appliances', 249.99, 20),
(7, 'Running Shoes', 'Sports', 89.99, 50),
(8, 'Yoga Mat', 'Sports', 29.99, 60),
(9, 'Dumbbell Set', 'Sports', 149.99, 25);