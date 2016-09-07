USE Northwind
GO

-- SELECT * FROM ViewOrders ORDER BY OrderID,ProductName

DROP VIEW ViewOrders
GO

CREATE VIEW ViewOrders
AS
SELECT
    Orders.OrderID
    ,CAST(Orders.OrderDate AS date) OrderDate
    ,STR(DATEPART(Year, Orders.OrderDate),4)
		+ '-' + REPLACE(STR(DATEPART(Month, Orders.OrderDate),2),' ','0') YearMonth
    ,STR(DATEPART(Year, Orders.OrderDate),4) Year
    ,REPLACE(STR(DATEPART(Month, Orders.OrderDate),2),' ','0') Month
    ,REPLACE(STR(DATEPART(Day, Orders.OrderDate),2),' ','0') Day
    ,REPLACE(STR(DATEPART(Week, Orders.OrderDate),2),' ','0') Week
	--
    ,Orders.CustomerID
    ,Customers.CompanyName CustomerName
    ,Customers.City
    ,COALESCE(Customers.Region, '') Region
    ,Customers.Country
	--
    ,Orders.EmployeeID
    ,Employees.FirstName + ' ' + Employees.LastName EmployeeName
	--
    ,OrderDetails.ProductID
    ,Products.ProductName
	--
    ,Products.CategoryID
    ,Categories.CategoryName
	--
    ,OrderDetails.Quantity Quantity
    ,CAST(OrderDetails.UnitPrice AS float) UnitPrice
    ,CAST(OrderDetails.Quantity * OrderDetails.UnitPrice AS float) Total
FROM
    Orders
    INNER JOIN Customers ON
        Customers.CustomerID = Orders.CustomerID
    INNER JOIN Employees ON
        Employees.EmployeeID = Orders.EmployeeID
    INNER JOIN [Order Details] OrderDetails ON
        OrderDetails.OrderID = Orders.OrderID
    INNER JOIN Products ON
        Products.ProductID = OrderDetails.ProductID
    INNER JOIN Categories ON
        Categories.CategoryID = Categories.CategoryID
GO