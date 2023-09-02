-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 30-08-2023 a las 05:05:04
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `etech_db`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `celulares`
--

CREATE TABLE `celulares` (
  `ID` int(11) NOT NULL,
  `Modelo` varchar(20) NOT NULL,
  `Marca` varchar(10) NOT NULL,
  `IMEI` varchar(15) DEFAULT NULL,
  `Estado` varchar(9) NOT NULL,
  `Cedula_Cliente` varchar(8) NOT NULL,
  `ID_Usuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `Cedula` varchar(8) NOT NULL,
  `Nombre` varchar(30) NOT NULL,
  `Telefono` varchar(8) NOT NULL,
  `CorreoElectronico` varchar(30) NOT NULL,
  `Celular` varchar(8) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `trabajos`
--

CREATE TABLE `trabajos` (
  `ID` int(11) NOT NULL,
  `Plazo` date DEFAULT NULL,
  `Presupuesto` int(11) DEFAULT NULL,
  `Problema` varchar(50) NOT NULL,
  `Fecha_Ingreso` date NOT NULL,
  `Adelanto` int(11) DEFAULT NULL,
  `ID_Celular` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `ID` int(11) NOT NULL,
  `Nombre` varchar(30) NOT NULL,
  `Contraseña` varchar(30) NOT NULL,
  `Telefono` varchar(8) DEFAULT NULL,
  `CorreoElectronico` varchar(30) NOT NULL,
  `Celular` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `celulares`
--
ALTER TABLE `celulares`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Cedula_Cliente` (`Cedula_Cliente`),
  ADD KEY `ID_Usuario` (`ID_Usuario`);

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`Cedula`);

--
-- Indices de la tabla `trabajos`
--
ALTER TABLE `trabajos`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_Celular` (`ID_Celular`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `celulares`
--
ALTER TABLE `celulares`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `trabajos`
--
ALTER TABLE `trabajos`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `celulares`
--
ALTER TABLE `celulares`
  ADD CONSTRAINT `celulares_ibfk_1` FOREIGN KEY (`Cedula_Cliente`) REFERENCES `clientes` (`Cedula`),
  ADD CONSTRAINT `celulares_ibfk_2` FOREIGN KEY (`ID_Usuario`) REFERENCES `usuarios` (`ID`);

--
-- Filtros para la tabla `trabajos`
--
ALTER TABLE `trabajos`
  ADD CONSTRAINT `trabajos_ibfk_1` FOREIGN KEY (`ID_Celular`) REFERENCES `celulares` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
