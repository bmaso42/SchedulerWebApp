use client_schedule;
--
-- Script to drop prior tables 
--

SET FOREIGN_KEY_CHECKS = 0;
SET @tarray = NULL;
SELECT GROUP_CONCAT('`', table_name, '`') INTO @tarray
  FROM information_schema.tables WHERE table_schema = (SELECT DATABASE());
SELECT IFNULL(@tarray,'dummy') INTO @tarray;
SET @tarray = CONCAT('DROP TABLE IF EXISTS ', @tarray);
PREPARE stmt FROM @tarray;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
SET FOREIGN_KEY_CHECKS = 1;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `userId` int(11) NOT NULL AUTO_INCREMENT,
  `userName` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;


--
-- Table structure for table `country`
--

DROP TABLE IF EXISTS `country`;




--
-- Table structure for table `city`
--

DROP TABLE IF EXISTS `city`;




--
-- Table structure for table `address`
--

DROP TABLE IF EXISTS `address`;



--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;

CREATE TABLE `customer` (
  `customerId` int(10) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `EmailAddress` varchar(50),

  PRIMARY KEY (`customerId`)--,
--  KEY `addressId` (`addressId`),
  --CONSTRAINT `customer_ibfk_1` FOREIGN KEY (`addressId`) REFERENCES `address` (`addressId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;

--
-- Table structure for table `appointment`
--

DROP TABLE IF EXISTS `appointment`;

CREATE TABLE `appointment` (
`appointmentId` int(10) NOT NULL AUTO_INCREMENT,
`customerId` int(10) NOT NULL,
`userId` int(11) NOT NULL,
-- `title` varchar(255) NOT NULL,
-- `description` text NOT NULL,
-- `location` text NOT NULL,
-- `contact` text NOT NULL,
`type` text NOT NULL,
-- `url` varchar(255) NOT NULL,
`start` datetime NOT NULL,
`end` datetime NOT NULL,
-- `createDate` datetime NOT NULL,
-- `createdBy` varchar(40) NOT NULL,
-- `lastUpdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
-- `lastUpdateBy` varchar(40) NOT NULL,
PRIMARY KEY (`appointmentId`),
-- KEY `userId` (`userId`),
-- KEY `appointment_ibfk_1` (`customerId`),
-- CONSTRAINT `appointment_ibfk_1` FOREIGN KEY (`customerId`) REFERENCES `customer` (`customerId`),
-- CONSTRAINT `appointment_ibfk_2` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`)
)-- ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;


