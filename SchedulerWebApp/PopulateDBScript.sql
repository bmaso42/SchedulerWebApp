use client_schedule;

INSERT INTO user (userName, password)
VALUES ('test', 'test');

INSERT INTO customer (customerId, FirstName, LastName, EmailAddress)
VALUES (1, 'Luigi', 'Mario', 'greensuit@nintendo.com'),
       (2, 'Doom', 'Guy', 'nightmare@id.com'),
       (3, 'Samus', 'Aran', 'metroid@prime.com');

INSERT INTO appointment (customerId, start)
VALUES ('1', '2022-05-27 08:00:00'),
       ('2', '2022-05-28 09:00:00'),
       ('3', '2022-02-28 10:00:00');