-- phpMyAdmin SQL Dump
-- version 4.4.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 20, 2017 at 10:33 PM
-- Server version: 5.6.26
-- PHP Version: 5.6.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hospital_management_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `login1`
--

CREATE TABLE IF NOT EXISTS `login1` (
  `UserName` varchar(10) NOT NULL,
  `Password` varchar(10) NOT NULL,
  `role` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `patient_history`
--

CREATE TABLE IF NOT EXISTS `patient_history` (
  `ID` int(5) NOT NULL,
  `PatientProf` varchar(100) NOT NULL,
  `PastHistory` varchar(100) NOT NULL,
  `FamilyHistory` varchar(100) NOT NULL,
  `Occupation` varchar(100) NOT NULL,
  `drug` varchar(100) NOT NULL,
  `alcohol` varchar(100) NOT NULL,
  `tobacco` varchar(100) NOT NULL,
  `drugall` varchar(100) NOT NULL,
  `otherall` varchar(100) NOT NULL,
  `presentco` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `patient_history`
--

INSERT INTO `patient_history` (`ID`, `PatientProf`, `PastHistory`, `FamilyHistory`, `Occupation`, `drug`, `alcohol`, `tobacco`, `drugall`, `otherall`, `presentco`) VALUES
(1, 'df', 'sdfsdf', 'sdfdsf', 'dsfds', 'sdfsdf', 'sdfsdf', 'sdfsdf', 'sdfasf', 'sdfsdf', 'sdf'),
(7, 'He is a sexy boy', 'he loves safia ', 'they are kasvi', 'he is a student', 'no drug', '10/0', '0/10', 'no allergy', 'no', 'he is good');

-- --------------------------------------------------------

--
-- Table structure for table `patient_info`
--

CREATE TABLE IF NOT EXISTS `patient_info` (
  `ID` int(7) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `roomm` varchar(20) NOT NULL,
  `sex` varchar(7) NOT NULL,
  `address` varchar(100) NOT NULL,
  `age` varchar(4) NOT NULL,
  `Nationality.` varchar(20) NOT NULL,
  `dateofadmission` varchar(40) NOT NULL,
  `timeofadmission` varchar(8) NOT NULL,
  `dateofdischarge` varchar(40) NOT NULL,
  `timeofdischarge` varchar(8) NOT NULL,
  `Date_Of_Consultation` varchar(30) NOT NULL,
  `timeofConsultation` varchar(9) NOT NULL,
  `doctorFindings` text NOT NULL,
  `finalD` varchar(200) NOT NULL,
  `Status` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `patient_info`
--

INSERT INTO `patient_info` (`ID`, `Name`, `roomm`, `sex`, `address`, `age`, `Nationality.`, `dateofadmission`, `timeofadmission`, `dateofdischarge`, `timeofdischarge`, `Date_Of_Consultation`, `timeofConsultation`, `doctorFindings`, `finalD`, `Status`) VALUES
(0, '', '', '', '', '', '', '', '', '', '', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `patient_infom`
--

CREATE TABLE IF NOT EXISTS `patient_infom` (
  `ID` int(7) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `roomm` varchar(20) NOT NULL,
  `sex` varchar(7) NOT NULL,
  `address` varchar(100) NOT NULL,
  `age` varchar(4) NOT NULL,
  `Nationality.` varchar(20) NOT NULL,
  `dateofadmission` varchar(40) NOT NULL,
  `timeofadmission` varchar(8) NOT NULL,
  `dateofdischarge` varchar(40) NOT NULL,
  `timeofdischarge` varchar(8) NOT NULL,
  `Date_Of_Consultation` varchar(30) NOT NULL,
  `timeofConsultation` varchar(9) NOT NULL,
  `doctorFindings` text NOT NULL,
  `finalD` varchar(200) NOT NULL,
  `Status` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `patient_medicine`
--

CREATE TABLE IF NOT EXISTS `patient_medicine` (
  `ID` int(5) NOT NULL,
  `Name` varchar(20) NOT NULL,
  `room` varchar(30) NOT NULL,
  `Medicine` varchar(50) NOT NULL,
  `Status` varchar(12) NOT NULL,
  `Time` varchar(8) NOT NULL,
  `Date` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `patient_medicinem`
--

CREATE TABLE IF NOT EXISTS `patient_medicinem` (
  `ID` int(5) NOT NULL,
  `Name` varchar(20) NOT NULL,
  `room` varchar(30) NOT NULL,
  `Medicine` varchar(50) NOT NULL,
  `Status` varchar(12) NOT NULL,
  `Time` varchar(8) NOT NULL,
  `Date` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `physical exam`
--

CREATE TABLE IF NOT EXISTS `physical exam` (
  `ID` int(5) NOT NULL,
  `Skin` varchar(100) NOT NULL,
  `HeadE` varchar(100) NOT NULL,
  `LYMPHN` varchar(100) NOT NULL,
  `Chest` varchar(100) NOT NULL,
  `Breast` varchar(100) NOT NULL,
  `Abdomen` varchar(100) NOT NULL,
  `Rectum` varchar(100) NOT NULL,
  `Genetalia` varchar(100) NOT NULL,
  `Lungs` varchar(100) NOT NULL,
  `Cardio` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `login1`
--
ALTER TABLE `login1`
  ADD PRIMARY KEY (`UserName`),
  ADD UNIQUE KEY `UserName` (`UserName`);

--
-- Indexes for table `patient_info`
--
ALTER TABLE `patient_info`
  ADD UNIQUE KEY `ID` (`ID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
