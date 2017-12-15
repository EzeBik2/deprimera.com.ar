-- phpMyAdmin SQL Dump
-- version 4.6.6
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:49209
-- Generation Time: Dec 01, 2017 at 03:28 AM
-- Server version: 5.7.9
-- PHP Version: 5.6.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `localdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `canchas`
--

CREATE TABLE `canchas` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `barrio` varchar(50) NOT NULL,
  `calle1` varchar(88) NOT NULL,
  `calle2` varchar(88) NOT NULL,
  `telefono` int(11) NOT NULL,
  `calificacion` int(11) NOT NULL,
  `cantidaddevotos` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `canchas`
--

INSERT INTO `canchas` (`id`, `nombre`, `barrio`, `calle1`, `calle2`, `telefono`, `calificacion`, `cantidaddevotos`) VALUES
(14, 'CanchaRandom', 'BarrioRandom', 'CalleRandom', '', 12312512, 0, 0),
(15, 'Liber', 'Almagro', 'almagro', '', 1252151, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `equipos`
--

CREATE TABLE `equipos` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `cantjug` int(11) NOT NULL,
  `calificacion` int(11) NOT NULL,
  `cantvotos` int(11) NOT NULL,
  `funciono` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `equipos`
--

INSERT INTO `equipos` (`id`, `nombre`, `cantjug`, `calificacion`, `cantvotos`, `funciono`) VALUES
(43, 'Independiente', 10, 0, 0, '');

-- --------------------------------------------------------

--
-- Table structure for table `equiposjugadores`
--

CREATE TABLE `equiposjugadores` (
  `id` int(11) NOT NULL,
  `estado` varchar(50) NOT NULL,
  `idequipo` int(11) NOT NULL,
  `idjugador` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `equiposjugadores`
--

INSERT INTO `equiposjugadores` (`id`, `estado`, `idequipo`, `idjugador`) VALUES
(73, 'En Formacion', 43, 16);

-- --------------------------------------------------------

--
-- Table structure for table `jugadores`
--

CREATE TABLE `jugadores` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `foto` varchar(50) NOT NULL,
  `edad` int(11) NOT NULL,
  `telefono` int(11) NOT NULL,
  `calificacion` int(11) NOT NULL,
  `cantidaddevotos` int(11) NOT NULL,
  `email` varchar(50) NOT NULL,
  `clave` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `jugadores`
--

INSERT INTO `jugadores` (`id`, `nombre`, `apellido`, `foto`, `edad`, `telefono`, `calificacion`, `cantidaddevotos`, `email`, `clave`) VALUES
(2, 'Martin', 'Alvarez', '', 17, 0, 0, 0, 'martxdx@gmail.com', 'poker1'),
(16, 'Pepe', 'Juarez', '', 11, 12412412, 0, 0, 'PepitoJuarez@gmail.com', 'poker1'),
(17, 'Edgardo', 'Alvarez', '', 17, 125125121, 0, 0, 'martxdx@gmail.com', 'poker1'),
(18, 'a', 'b', '', 1, 3, 0, 0, 'c@gmail.com', 'poker1'),
(19, 'Ezequiel', 'Bikiel', '', 17, 0, 0, 0, 'elbikiel@gmail.com', '123');

-- --------------------------------------------------------

--
-- Table structure for table `partidos`
--

CREATE TABLE `partidos` (
  `id` int(11) NOT NULL,
  `fecha` datetime NOT NULL,
  `idcancha` int(11) NOT NULL,
  `cantjug` int(11) NOT NULL,
  `idcamiseta1` int(11) NOT NULL,
  `idcamiseta2` int(11) NOT NULL,
  `sepuede` varchar(50) NOT NULL,
  `duracion` int(11) NOT NULL,
  `calificacion` int(11) NOT NULL,
  `cantidaddevotos` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `partidos`
--

INSERT INTO `partidos` (`id`, `fecha`, `idcancha`, `cantjug`, `idcamiseta1`, `idcamiseta2`, `sepuede`, `duracion`, `calificacion`, `cantidaddevotos`) VALUES
(20, '2017-01-01 01:01:01', 14, 0, 0, 0, '', 0, 0, 0),
(21, '2017-01-01 01:01:01', 14, 0, 0, 0, '', 0, 0, 0),
(22, '2017-01-01 01:01:01', 15, 0, 0, 0, '', 0, 0, 0),
(24, '2017-01-01 01:01:01', 15, 0, 0, 0, '', 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `partidosjugadores`
--

CREATE TABLE `partidosjugadores` (
  `id` int(11) NOT NULL,
  `estado` varchar(50) NOT NULL,
  `rol` varchar(50) NOT NULL,
  `idpartido` int(11) NOT NULL,
  `idjugador` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `partidosjugadores`
--

INSERT INTO `partidosjugadores` (`id`, `estado`, `rol`, `idpartido`, `idjugador`) VALUES
(2, 'En formacion', '', 20, 16),
(17, 'En formacion', '', 21, 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `canchas`
--
ALTER TABLE `canchas`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `equipos`
--
ALTER TABLE `equipos`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `equiposjugadores`
--
ALTER TABLE `equiposjugadores`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `jugadores`
--
ALTER TABLE `jugadores`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `partidos`
--
ALTER TABLE `partidos`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `partidosjugadores`
--
ALTER TABLE `partidosjugadores`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `canchas`
--
ALTER TABLE `canchas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT for table `equipos`
--
ALTER TABLE `equipos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;
--
-- AUTO_INCREMENT for table `equiposjugadores`
--
ALTER TABLE `equiposjugadores`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=74;
--
-- AUTO_INCREMENT for table `jugadores`
--
ALTER TABLE `jugadores`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
--
-- AUTO_INCREMENT for table `partidos`
--
ALTER TABLE `partidos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;
--
-- AUTO_INCREMENT for table `partidosjugadores`
--
ALTER TABLE `partidosjugadores`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
