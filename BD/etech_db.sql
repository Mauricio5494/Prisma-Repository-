-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 02-09-2023 a las 01:51:41
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
  `Modelo` varchar(20) NOT NULL,
  `Marca` varchar(10) NOT NULL,
  `IMEI` varchar(15) DEFAULT NULL,
  `Estado` varchar(9) NOT NULL,
  `Cedula_Cliente` varchar(8) NOT NULL,
  `ID_Usuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `celulares`
--

INSERT INTO `celulares` (`ID`, `Modelo`, `Marca`, `IMEI`, `Estado`, `Cedula_Cliente`, `ID_Usuario`) VALUES
(13, 'Samsung epico xd', 'samsung', '123432145', 'Arreglado', '56541591', 3),
(14, 'Samsung J10', 'Apple', '000564244', 'Arreglado', '56541591', 3),
(15, 'Samsung epico xd', 'samsung', '123432145', 'Averiado', '56541591', 3),
(16, 'Samsung epico xd', 'samsung', '123432145', 'Arreglado', '56541591', 3),
(17, 'Samsung epico xd', 'samsung', '123432145', 'Arreglado', '56541591', 3),
(18, 'redmi 9 C', 'Xiaomi', '123432145', 'Arreglado', '56541591', 3),
(19, 'Redmi 9 C', 'Xiaomi', '1234341234', 'Averiado', '54742365', 3);

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

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`Cedula`, `Nombre`, `Telefono`, `CorreoElectronico`, `Celular`) VALUES
('54742365', 'Mauricio', '1234234', 'namelessdebl0@gmail.com', '96275530'),
('56541591', 'mateo', '1234234', 'xdxdxddd@hotmail.com', '12344');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `trabajos`
--

CREATE TABLE `trabajos` (
  `ID` int(11) NOT NULL,
  `Plazo` date DEFAULT NULL,
  `Presupuesto` int(11) DEFAULT NULL,
  `Problema` varchar(255) NOT NULL,
  `Fecha_Ingreso` date NOT NULL,
  `Adelanto` int(11) DEFAULT NULL,
  `ID_Celular` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `trabajos`
--

INSERT INTO `trabajos` (`ID`, `Plazo`, `Presupuesto`, `Problema`, `Fecha_Ingreso`, `Adelanto`, `ID_Celular`) VALUES
(1, '2023-09-14', 123, 'No jala wasap', '2023-09-12', 23412, 18),
(2, '2023-09-14', 123, 'Esta rota la bateria', '2023-09-12', 23412, 13),
(3, '2023-09-06', 0, 'No prende la pantalla, la cámara no enciende o no ', '2023-09-23', 0, 15);

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
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`ID`, `Nombre`, `Contraseña`, `Telefono`, `CorreoElectronico`, `Celular`) VALUES
(3, 'Mateo Parodi', 'mateo123', '2134344', 'mateprodi12@gmail.com', '12341234');

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT de la tabla `trabajos`
--
ALTER TABLE `trabajos`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

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
