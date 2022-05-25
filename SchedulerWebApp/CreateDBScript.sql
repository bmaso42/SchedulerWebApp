use client_schedule;
--
-- Script to drop prior tables 
--
DROP TABLE IF EXISTS `address`;
DROP TABLE IF EXISTS `appointment`;
DROP TABLE IF EXISTS `city`;
DROP TABLE IF EXISTS `country`;
DROP TABLE IF EXISTS `customer`;
DROP TABLE IF EXISTS `user`;

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

  PRIMARY KEY (`customerId`)

) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;

--
-- Table structure for table `appointment`
--

DROP TABLE IF EXISTS `appointment`;

CREATE TABLE `appointment` (
`appointmentId` int(10) NOT NULL AUTO_INCREMENT,
`customerId` int(10) NOT NULL,
`start` datetime NOT NULL,
PRIMARY KEY (`appointmentId`)
)

