CREATE DATABASE StoreDB;

USE StoreDB;

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    order_status INT,
    store_id INT
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2)
);

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100)
);

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE order_items (
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2)
);

CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT
);

INSERT INTO customers VALUES
(1,'John','Smith'),
(2,'Emma','Johnson'),
(3,'Michael','Brown');

INSERT INTO stores VALUES
(1,'Chennai Store'),
(2,'Madurai Store');

INSERT INTO brands VALUES
(1,'Nike'),
(2,'Adidas'),
(3,'Puma');

INSERT INTO categories VALUES
(1,'Shoes'),
(2,'Clothing');

INSERT INTO products VALUES
(1,'Running Shoes',1,1,2023,1200),
(2,'Sports T-Shirt',2,2,2024,800),
(3,'Training Shoes',3,1,2022,600),
(4,'Casual T-Shirt',1,2,2023,400);

INSERT INTO orders VALUES
(101,1,'2024-02-01',1,1),
(102,2,'2024-02-10',4,1),
(103,3,'2024-03-05',4,2);

INSERT INTO order_items VALUES
(101,1,2,1200,0.10),
(102,2,1,800,0.05),
(103,3,3,600,0.00);

INSERT INTO stocks VALUES
(1,1,50),
(1,2,40),
(2,3,30),
(2,4,20);


--Level-1 Problem 1
SELECT 
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
FROM customers c
INNER JOIN orders o
ON c.customer_id = o.customer_id
WHERE o.order_status = 1 
   OR o.order_status = 4
ORDER BY o.order_date DESC;


--Level-1 Problem 2
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b
ON p.brand_id = b.brand_id
INNER JOIN categories c
ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC;


--Level-2 Problem 1
SELECT 
    s.store_name,
    SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM stores s
INNER JOIN orders o
ON s.store_id = o.store_id
INNER JOIN order_items oi
ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;

--Level-2 Problem 2
SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS stock_quantity,
    SUM(oi.quantity) AS total_quantity_sold
FROM stocks st
INNER JOIN products p
ON st.product_id = p.product_id
INNER JOIN stores s
ON st.store_id = s.store_id
LEFT JOIN order_items oi
ON st.product_id = oi.product_id
GROUP BY p.product_name, s.store_name, st.quantity
ORDER BY p.product_name;