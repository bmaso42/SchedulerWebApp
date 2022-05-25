use client_schedule;

INSERT INTO user (userName, password)
VALUES ('test', 'test');

INSERT INTO customer (FirstName, LastName, EmailAddress)
VALUES ('Luigi', 'Mario', 'greensuit@nintendo.com'),
       ('Doom', 'Guy', 'nightmare@id.com'),
       ('Samus', 'Aran', 'metroid@prime.com');

INSERT INTO appointment (customerId, start)
VALUES ('1', '2022-05-27 08:00:00'),
       ('2', '2022-05-28 09:00:00'),
       ('3', '2022-02-28 10:00:00');