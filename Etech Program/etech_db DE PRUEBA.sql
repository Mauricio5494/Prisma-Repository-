-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 31-10-2023 a las 01:53:18
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.0.28

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
  `Localidad` varchar(255) NOT NULL,
  `ModeloYOmarca` varchar(255) NOT NULL,
  `IMEI` varchar(15) DEFAULT NULL,
  `Estado` varchar(255) NOT NULL,
  `Ingreso` date NOT NULL,
  `Plazo` date NOT NULL,
  `Detalles` text NOT NULL,
  `Presupuesto` int(255) DEFAULT NULL,
  `Adelanto` int(255) DEFAULT NULL,
  `Cedula_Cliente` varchar(8) NOT NULL,
  `ID_Usuario` int(11) NOT NULL,
  `Baja` int(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `celulares`
--

INSERT INTO `celulares` (`ID`, `Localidad`, `ModeloYOmarca`, `IMEI`, `Estado`, `Ingreso`, `Plazo`, `Detalles`, `Presupuesto`, `Adelanto`, `Cedula_Cliente`, `ID_Usuario`, `Baja`) VALUES
(1, '123', '423', '342', '234', '2023-10-10', '2023-10-11', '234', NULL, NULL, '54634565', 1, 0),
(2, '', '3452', '', 'Averiado', '2023-10-29', '2023-10-29', '234453', NULL, NULL, '54634565', 1, 0),
(3, '', 'Xiaomi Redmi 9C', '', 'Averiado', '2023-11-05', '2023-10-27', 'Se le pijio la cámaraa tambien.', NULL, NULL, '54634565', 1, 0),
(4, '', '234234', '', 'En Proceso', '2023-11-05', '2023-10-19', 'Coso', NULL, NULL, '54634565', 1, 0),
(5, 'pedro', 'Si', 'no', 'Arreglado', '2023-10-10', '2023-10-18', 'nohay', 90, 0, '54634565', 1, 0),
(6, '', 'pepo papo', '', 'En Espera', '2023-10-29', '2023-10-29', 'culo', NULL, NULL, '54634565', 1, 0),
(7, '', 'si', '', 'En Proceso', '2023-11-05', '2023-10-29', 'z', NULL, NULL, '54634565', 1, 0),
(8, '', '123', '', 'Averiado', '2023-10-29', '2023-11-05', 's', NULL, NULL, '54634565', 1, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `Cedula` varchar(8) NOT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Telefono` varchar(8) DEFAULT NULL,
  `CorreoElectronico` varchar(255) DEFAULT NULL,
  `Celular` varchar(9) DEFAULT NULL,
  `Baja` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`Cedula`, `Nombre`, `Telefono`, `CorreoElectronico`, `Celular`, `Baja`) VALUES
('34123423', 'Hernan Bolaños', '', 's', '349892349', 0),
('54634565', 'pedro alfonso', '', 'mierda@gmail.com', '098897389', 0),
('84738673', 'Jose Kinoa', '', 's', '400', 0),
('93482828', 'Juliana deArco', '', '20', '20', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sucursales`
--

CREATE TABLE `sucursales` (
  `ID` int(11) NOT NULL,
  `Departamento` varchar(30) NOT NULL,
  `Sucursal` varchar(255) NOT NULL,
  `Contacto` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='si.';

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `trabajos`
--

CREATE TABLE `trabajos` (
  `ID` int(11) NOT NULL,
  `ID_Tecnico` int(11) NOT NULL,
  `Plazo` date DEFAULT NULL,
  `Presupuesto` int(11) DEFAULT NULL,
  `Problema` varchar(255) NOT NULL,
  `Fecha_Ingreso` date NOT NULL,
  `Adelanto` int(11) DEFAULT NULL,
  `ID_Celular` int(11) NOT NULL,
  `Baja` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `trabajos`
--

INSERT INTO `trabajos` (`ID`, `ID_Tecnico`, `Plazo`, `Presupuesto`, `Problema`, `Fecha_Ingreso`, `Adelanto`, `ID_Celular`, `Baja`) VALUES
(1, 1, '2023-10-31', 123, '123', '2023-10-11', 123, 1, 0),
(2, 1, '2023-10-26', 500, 'No hay... esto solo es una prueba', '2023-10-23', 70, 2, 0),
(3, 1, '2023-10-24', 500, 'No hay... esto solo es una prueba', '2023-10-23', 70, 2, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `ID` int(11) NOT NULL,
  `Nombre` varchar(30) NOT NULL,
  `Contraseña` text NOT NULL,
  `Telefono` varchar(8) DEFAULT NULL,
  `CorreoElectronico` varchar(255) NOT NULL,
  `Celular` varchar(9) NOT NULL,
  `Nivel` int(1) NOT NULL DEFAULT 1,
  `Baja` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`ID`, `Nombre`, `Contraseña`, `Telefono`, `CorreoElectronico`, `Celular`, `Nivel`, `Baja`) VALUES
(1, 'mauri', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '', 'si', 'no', 1, 0),
(2, 'Jose', '123', 'tampoco', 'si', 'no', 1, 0);

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
-- Indices de la tabla `sucursales`
--
ALTER TABLE `sucursales`
  ADD PRIMARY KEY (`ID`);

--
-- Indices de la tabla `trabajos`
--
ALTER TABLE `trabajos`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID_Celular` (`ID_Celular`),
  ADD KEY `idx_ID-Tecnico_trabajos` (`ID_Tecnico`);

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `sucursales`
--
ALTER TABLE `sucursales`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `trabajos`
--
ALTER TABLE `trabajos`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

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
  ADD CONSTRAINT `trabajos_ibfk_1` FOREIGN KEY (`ID_Celular`) REFERENCES `celulares` (`ID`),
  ADD CONSTRAINT `trabajos_ibfk_2` FOREIGN KEY (`ID_Tecnico`) REFERENCES `usuarios` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
