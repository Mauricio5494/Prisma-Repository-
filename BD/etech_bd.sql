-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost
-- Tiempo de generación: 06-05-2023 a las 01:49:43
-- Versión del servidor: 8.0.32
-- Versión de PHP: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `etech_bd`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `celular`
--

CREATE TABLE `celular` (
  `ID_Celular` int NOT NULL,
  `ID_Tecnico_FK` int DEFAULT NULL,
  `Marca` varchar(15) COLLATE utf8mb4_spanish_ci NOT NULL,
  `Modelo` varchar(15) COLLATE utf8mb4_spanish_ci NOT NULL,
  `Patrón` varchar(9) COLLATE utf8mb4_spanish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cliente`
--

CREATE TABLE `cliente` (
  `ID_Cliente` int NOT NULL,
  `Nombre` varchar(50) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `Contacto` varchar(12) COLLATE utf8mb4_spanish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tecnico`
--

CREATE TABLE `tecnico` (
  `Nombre` varchar(50) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `Turno` varchar(20) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `contacto` varchar(12) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `ID_Tecnico` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `trabajo`
--

CREATE TABLE `trabajo` (
  `ID_Trabajo` int NOT NULL,
  `Problema` varchar(100) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `Solucion` varchar(100) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `Adelanto` int DEFAULT NULL,
  `Precio` int DEFAULT NULL,
  `Fecha_Ingreso` date DEFAULT NULL,
  `Fecha_Entrega` date DEFAULT NULL,
  `Presupuesto_AprobORnot` bit(1) DEFAULT NULL,
  `Presupuesto_Monto` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `celular`
--
ALTER TABLE `celular`
  ADD PRIMARY KEY (`ID_Celular`),
  ADD KEY `FK_tecnico` (`ID_Tecnico_FK`);

--
-- Indices de la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`ID_Cliente`);

--
-- Indices de la tabla `tecnico`
--
ALTER TABLE `tecnico`
  ADD PRIMARY KEY (`ID_Tecnico`),
  ADD UNIQUE KEY `ID_Tecnico` (`ID_Tecnico`),
  ADD UNIQUE KEY `ID_Tecnico_2` (`ID_Tecnico`);

--
-- Indices de la tabla `trabajo`
--
ALTER TABLE `trabajo`
  ADD PRIMARY KEY (`ID_Trabajo`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `celular`
--
ALTER TABLE `celular`
  MODIFY `ID_Celular` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `cliente`
--
ALTER TABLE `cliente`
  MODIFY `ID_Cliente` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tecnico`
--
ALTER TABLE `tecnico`
  MODIFY `ID_Tecnico` int NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `celular`
--
ALTER TABLE `celular`
  ADD CONSTRAINT `celular_ibfk_1` FOREIGN KEY (`ID_Tecnico_FK`) REFERENCES `tecnico` (`ID_Tecnico`) ON DELETE RESTRICT ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
