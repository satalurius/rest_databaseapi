DROP TABLE IF EXISTS customers_addresses;
DROP TABLE IF EXISTS customers;

CREATE TABLE IF NOT EXISTS customers(
    ctr_number  INTEGER PRIMARY KEY NOT NULL,
    email VARCHAR(50) NOT NULL,
    first_name VARCHAR(20) NOT NULL,
    last_name VARCHAR(30) NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    current_balance DECIMAL(6, 2) NOT NULL 
);

CREATE TABLE IF NOT EXISTS customers_addresses(
    cas_id INTEGER PRIMARY KEY NOT NULL,
    city VARCHAR(15) NOT NULL,
    postal_code VARCHAR(7) NOT NULL,
    ctr_number INTEGER NOT NULL,
    
    FOREIGN KEY (ctr_number) REFERENCES customers (ctr_number) ON DELETE CASCADE
);


insert into customers values(
    "256189", 
    "vasily@email.com",
    "Василий",
    "Петров",
    "81234832156",
    "5000"
);
insert into customers values(
    "356782", 
    "nikolay@email.com",
    "Николай",
    "Николаев",
    "84234452756",
    "100000"
);
insert into customers values(
    "843210", 
    "anatoliy@email.com",
    "Анатолий",
    "Ножнин",
    "85223730026",
    "8000"
);


insert into customers_addresses values(
    "1",
    "Ростов-на-дону",
    "3412879",
    "256189"
);

insert into customers_addresses values(
    "2",
    "Ростов-на-дону",
    "3412879",
    "356782"
);

insert into customers_addresses values(
    "3",
    "Ростов-на-дону",
    "3412879",
    "843210"
);