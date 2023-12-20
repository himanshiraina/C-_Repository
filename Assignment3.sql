--Creating database CMS
CREATE DATABASE CMS;

--Creating tables
--User

CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Name VARCHAR(255),
    Email VARCHAR(255) UNIQUE,
    Password VARCHAR(255),
    ContactNumber VARCHAR(20),
    Address TEXT
);


--Courier
CREATE TABLE Courier (
    CourierID INT PRIMARY KEY,
    SenderName VARCHAR(255),
    SenderAddress TEXT,
    ReceiverName VARCHAR(255),
    ReceiverAddress TEXT,
    Weight DECIMAL(5, 2),
    Status VARCHAR(50),
    TrackingNumber VARCHAR(20) UNIQUE,
    DeliveryDate DATE
);

--CourierServices
CREATE TABLE CourierServices (
    ServiceID INT PRIMARY KEY,
    ServiceName VARCHAR(100),
    Cost DECIMAL(8, 2)
);

--Employee
CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY,
    Name VARCHAR(255),
    Email VARCHAR(255) UNIQUE,
    ContactNumber VARCHAR(20),
    Role VARCHAR(50),
    Salary DECIMAL(10, 2)
);

--Location
CREATE TABLE Location (
    LocationID INT PRIMARY KEY,
    LocationName VARCHAR(100),
    Address TEXT
);

--Payment
CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY,
    CourierID INT,
    LocationID INT,
    Amount DECIMAL(10, 2),
    PaymentDate DATE,
    FOREIGN KEY (CourierID) REFERENCES Courier(CourierID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (LocationID) REFERENCES Location(LocationID) ON DELETE CASCADE ON UPDATE CASCADE
);


DELETE FROM Courier
where CourierID IN (1,2,3,4,5)
ALTER TABLE Courier
ADD CourierStaffId INT;
CREATE TABLE ADMIN(
Courier_StaffID INT PRIMARY KEY,
NAME VARCHAR(50),
CONTACT_NO VARCHAR(20))




-- Add SenderID and ReceiverID columns to the Courier table
ALTER TABLE Courier
ADD SenderID INT
ALTER TABLE Courier
ADD ReceiverID INT;

-- Add foreign key constraints
ALTER TABLE Courier
ADD FOREIGN KEY (SenderID) REFERENCES Users (UserID) ON DELETE CASCADE ON UPDATE CASCADE;

-- Add EmployeeID column to the Courier table
ALTER TABLE Courier
ADD EmployeeID INT;

-- Add foreign key constraint
ALTER TABLE Courier
ADD FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE;

-- Add ServiceID column to the Courier table
ALTER TABLE Courier
ADD ServiceID INT;

-- Add foreign key constraint
ALTER TABLE Courier
ADD FOREIGN KEY (ServiceID) REFERENCES CourierServices(ServiceID) ON DELETE CASCADE ON UPDATE CASCADE;

-- Add ServiceID column to the Payment table
ALTER TABLE Payment
ADD ServiceID INT;

-- Add foreign key constraint
ALTER TABLE Payment
ADD FOREIGN KEY (ServiceID) REFERENCES CourierServices(ServiceID);

--Inserting values into tables
INSERT INTO Users (UserID, Name, Email, Password, ContactNumber, Address)
VALUES
    (1, 'John Doe', 'john@example.com', 'password123', '1234567890', '123 Main St'),
    (2, 'Alice Smith', 'alice@example.com', 'securePwd', '9876543210', '456 Elm St'),
    (3, 'Bob Johnson', 'bob@example.com', 'pass1234', '5551234567', '789 Oak St'),
    (4, 'Emily Brown', 'emily@example.com', 'myPwd567', '3334445555', '321 Pine St'),
    (5, 'Michael Davis', 'michael@example.com', 'safePwd987', '7778889999', '654 Cedar St');

INSERT INTO Courier (CourierID, SenderName, SenderAddress, ReceiverName, ReceiverAddress, Weight, Status, TrackingNumber, DeliveryDate)
VALUES
    (1, 'John Smith', '123 Main St, CityA', 'Alice Johnson', '456 Elm St, CityB', 2.5, 'In Transit', 'TRK123456', '2023-12-01'),
    (2, 'Emily Davis', '789 Oak St, CityC', 'Bob White', '321 Pine St, CityD', 3.2, 'Delivered', 'TRK789012', '2023-11-28'),
    (3, 'Sarah Green', '654 Cedar St, CityE', 'David Brown', '987 Maple St, CityF', 1.8, 'Pending', 'TRK345678', NULL),
    (4, 'James Lee', '111 Oak St, CityG', 'Sophia Garcia', '222 Elm St, CityH', 4.7, 'In Transit', 'TRK901234', '2023-12-03'),
    (5, 'Olivia Wilson', '333 Pine St, CityI', 'Ethan Taylor', '444 Oak St, CityJ', 2.0, 'Pending', 'TRK567890', NULL);


INSERT INTO CourierServices (ServiceID, ServiceName, Cost)
VALUES
    (1, 'Standard Delivery', 15.99),
    (2, 'Express Delivery', 25.99),
    (3, 'Same-Day Delivery', 35.99),
    (4, 'International Delivery', 45.99),
    (5, 'Overnight Delivery', 30.99);


INSERT INTO Employee (EmployeeID, Name, Email, ContactNumber, Role, Salary)
VALUES
    (1, 'Alice Johnson', 'alice@example.com', '1234567890', 'Manager', 60000.00),
    (2, 'Bob Smith', 'bob@example.com', '9876543210', 'Developer', 50000.00),
    (3, 'Charlie Brown', 'charlie@example.com', '5551234567', 'Sales Associate', 45000.00),
    (4, 'Diana Garcia', 'diana@example.com', '3334445555', 'HR Specialist', 55000.00),
    (5, 'Eva White', 'eva@example.com', '7778889999', 'Marketing Manager', 65000.00);


INSERT INTO Location (LocationID, LocationName, Address)
VALUES
    (1, 'Office A', '123 Main St, CityA'),
    (2, 'Office B', '456 Elm St, CityB'),
    (3, 'Warehouse', '789 Oak St, CityC'),
    (4, 'Branch Office', '321 Pine St, CityD'),
    (5, 'Distribution Center', '654 Cedar St, CityE');


INSERT INTO Payment (PaymentID, CourierID, LocationID, Amount, PaymentDate)
VALUES
    (1, 1, 2, 50.00, '2023-12-01'),
    (2, 2, 3, 75.50, '2023-11-28'),
    (3, 3, 1, 30.25, '2023-12-03'),
    (4, 4, 5, 45.75, '2023-12-02'),
    (5, 5, 4, 60.00, '2023-11-30');

SELECT * FROM Users
SELECT * FROM Courier
SELECT * FROM CourierServices
SELECT * FROM Employee
SELECT * FROM Location
SELECT * FROM Payment
--Queries
delete from Courier

--1. List all customers
SELECT * FROM Users;
--2. List all orders for a specific customerSELECT * FROM CourierWHERE CourierID=2;--3. List all couriers
SELECT * FROM Courier;
--4. List all packages for a specific order
SELECT * FROM Courier 
WHERE CourierID = 1;

--5. List all deliveries for a specific courier
SELECT * FROM Courier 
WHERE CourierID = 1;
--6. List all undelivered packages
SELECT * FROM Courier
WHERE Status != 'Delivered';

--7. List all packages that are scheduled for delivery today
SELECT * FROM Courier
WHERE DeliveryDate=(SELECT GETDATE());

--8. List all packages with a specific status
SELECT * FROM Courier
WHERE Status = 'In Transit';

--9. Calculate the total number of packages for each courier
SELECT CourierID, COUNT(*) AS TotalPackages
FROM Courier
GROUP BY CourierID;

--10. Find the average delivery time for each courier
SELECT CourierID, AVG(DATEDIFF(Day, DeliveryDate, DeliveryDate)) AS AverageDeliveryTime
FROM Courier
WHERE DeliveryDate IS NOT NULL AND DeliveryDate IS NOT NULL
GROUP BY CourierID;

--11. List all packages with a specific weight range
SELECT * FROM Courier
WHERE Weight BETWEEN 2 AND 4;

--12. Retrieve employees whose names contain 'John'
SELECT * FROM Employee
WHERE Name LIKE '%John%';

--13. Retrieve all courier records with payments greater than $50SELECT * FROM Courier c
INNER JOIN Payment p ON c.CourierID = p.CourierID
WHERE p.Amount > 50.00;
--14. Find the total number of couriers handled by each employee
SELECT e.EmployeeID, e.Name, COUNT(c.CourierID) AS TotalCouriersHandled
FROM Employee e
LEFT JOIN Courier c ON e.Name = c.SenderName OR e.Name = c.ReceiverName
GROUP BY e.EmployeeID, e.Name;

--15. Calculate the total revenue generated by each location
SELECT LocationID, SUM(Amount) as TotalRevenueGenerated FROM Payment GROUP BY LocationID;

--16. Find the total number of couriers delivered to each location
SELECT ReceiverID, COUNT(*) as TotalCouriers FROM Courier GROUP BY ReceiverID;

--17. Find the courier with the highest average delivery time
-- Assume that DeliveryTime exist
SELECT TOP 1 CourierID, AVG(DeliveryTime) as AverageDeliveryTime 
FROM Courier 
GROUP BY CourierID 
ORDER BY AverageDeliveryTime DESC;

--18. Find Locations with Total Payments Less Than a Certain Amount
SELECT LocationID FROM Payment GROUP BY LocationID HAVING SUM(Amount) < 5000;
--19. Calculate Total Payments per Location
SELECT LocationID, SUM(Amount) as TotalPayments FROM Payment GROUP BY LocationID;
--20. Retrieve couriers who have received payments totaling more than $1000 in a specific location (LocationID = X)
SELECT CourierID FROM Payment WHERE LocationID = 2 GROUP BY CourierID HAVING SUM(Amount) > 1000;
--21. Retrieve couriers who have received payments totaling more than $1000 after a certain date (PaymentDate > 'YYYY-MM-DD')
SELECT CourierID FROM Payment WHERE PaymentDate > '2023-11-29' GROUP BY CourierID HAVING SUM(Amount) > 1000;
--22. Retrieve locations where the total amount received is more than $5000 before a certain date (PaymentDate > 'YYYY-MM-DD')SELECT LocationID FROM Payment WHERE PaymentDate < '2023-12-01' GROUP BY LocationID HAVING SUM(Amount) > 5000;--23. Retrieve Payments with Courier Information
SELECT * FROM Payment p JOIN Courier c ON p.CourierID = c.CourierID;
--24. Retrieve Payments with Location Information
SELECT * FROM Payment p JOIN Location l ON p.LocationID = l.LocationID;
--25. Retrieve Payments with Courier and Location Information
SELECT * FROM Payment p JOIN Courier c ON p.CourierID = c.CourierID JOIN Location l ON p.LocationID = l.LocationID;
--26. List all payments with courier details
SELECT * FROM Payment p JOIN Courier c ON p.CourierID = c.CourierID;
--27. Total payments received for each courier
SELECT CourierID, SUM(Amount) as TotalPaymentsRecieved FROM Payment GROUP BY CourierID;
--28. List payments made on a specific date
SELECT * FROM Payment WHERE PaymentDate = '2023-12-03';
--29. Get Courier Information for Each Payment
SELECT * FROM Payment p JOIN Courier c ON p.CourierID = c.CourierID;
--30. Get Payment Details with Location
SELECT * FROM Payment p JOIN Location l ON p.LocationID = l.LocationID;
--31. Calculating Total Payments for Each Courier
SELECT CourierID, SUM(Amount) as TotalPayments FROM Payment GROUP BY CourierID;
--32. List Payments Within a Date Range
SELECT * FROM Payment WHERE PaymentDate BETWEEN '2023-05-01' AND '2023-12-01';
--33. Retrieve a list of all users and their corresponding courier records, including cases where there are no matches on either side

--34. Retrieve a list of all couriers and their corresponding services, including cases where there are no matches on either side

--35. Retrieve a list of all employees and their corresponding payments, including cases where there are no matches on either side
--36. List all users and all courier services, showing all possible combinations
SELECT * FROM "Users" CROSS JOIN CourierServices;
--37. List all employees and all locations, showing all possible combinations
SELECT * FROM Employee CROSS JOIN Location;
--38. Retrieve a list of couriers and their corresponding sender information (if available)
SELECT * FROM Courier c LEFT JOIN "Users" u ON c.SenderID = u.UserID;
--39. Retrieve a list of couriers and their corresponding receiver information (if available)
SELECT * FROM Courier c LEFT JOIN "Users" u ON c.ReceiverID = u.UserID;
--40. Retrieve a list of couriers along with the courier service details (if available)
SELECT * FROM Courier c LEFT JOIN CourierServices cs ON c.ServiceID = cs.ServiceID;
--41. Retrieve a list of employees and the number of couriers assigned to each employee
SELECT EmployeeID, COUNT(*) as TotalCouriers FROM Courier GROUP BY EmployeeID;
--42. Retrieve a list of locations and the total payment amount received at each location
SELECT LocationID, SUM(Amount) as TotalPayments FROM Payment GROUP BY LocationID;
--43. Retrieve all couriers sent by the same sender (based on SenderName)
SELECT * FROM Courier WHERE SenderName = 'Ravi Kumar';
--44. List all employees who share the same role
SELECT * FROM Employee WHERE Role = 'Courier';
--45. Retrieve all payments made for couriers sent from the same location
SELECT * FROM Payment p JOIN Courier c ON p.CourierID = c.CourierID WHERE c.SenderID = 1;
--46. Retrieve all couriers sent from the same location (based on SenderAddress)
SELECT * FROM Courier WHERE SenderAddress LIKE '123 MG Road, Bangalore';
--47. List employees and the number of couriers they have delivered
SELECT EmployeeID, COUNT(*) as TotalDeliveries FROM Courier WHERE Status = 'Delivered' 
GROUP BY EmployeeID;
--48. Find couriers that were paid an amount greater than the cost of their respective courier services
SELECT * FROM Courier c JOIN Payment p ON c.CourierID = p.CourierID 
JOIN CourierServices cs ON c.ServiceID = cs.ServiceID WHERE p.Amount > cs.Cost;
--49. Find couriers that have a weight greater than the average weight of all couriers
SELECT * FROM Courier WHERE Weight > (SELECT AVG(Weight) FROM Courier);
--50. Find the names of all employees who have a salary greater than the average salary
SELECT Name FROM Employee WHERE Salary > (SELECT AVG(Salary) FROM Employee);
--51. Find the total cost of all courier services where the cost is less than the maximum cost
SELECT SUM(Cost) FROM CourierServices WHERE Cost < (SELECT MAX(Cost) FROM CourierServices);
--52. Find all couriers that have been paid for
SELECT * FROM Courier WHERE CourierID IN (SELECT CourierID FROM Payment);
--53. Find the locations where the maximum payment amount was made
SELECT LocationID FROM Payment WHERE Amount = (SELECT MAX(Amount) FROM Payment);
--54. Find all couriers whose weight is greater than the weight of all couriers sent by a specific sender (e.g., 'SenderName'):SELECT * FROM Courier WHERE Weight > (SELECT AVG(Weight) FROM Courier WHERE SenderName = 'Ravi Kumar');



CREATE TABLE Orders (
    OrderId INT PRIMARY KEY,
    DeliveryDate DATE,
    CustomerId INT, 
    CONSTRAINT FK_Customer_Order FOREIGN KEY (CustomerId) REFERENCES Users(UserID) ON DELETE CASCADE ON UPDATE CASCADE
);

Select * from Users;
