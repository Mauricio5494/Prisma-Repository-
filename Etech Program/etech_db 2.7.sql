-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 13-11-2023 a las 23:55:21
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
CREATE DATABASE IF NOT EXISTS `etech_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `etech_db`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `celulares`
--

DROP TABLE IF EXISTS `celulares`;
CREATE TABLE `celulares` (
  `ID` int(11) NOT NULL,
  `Localidad` varchar(255) NOT NULL,
  `ModeloYOmarca` varchar(255) NOT NULL,
  `IMEI` varchar(15) DEFAULT NULL,
  `Estado` varchar(255) NOT NULL,
  `Ingreso` date NOT NULL,
  `Plazo` date NOT NULL,
  `Detalles` text NOT NULL,
  `Presupuesto` varchar(255) DEFAULT NULL,
  `Adelanto` varchar(255) DEFAULT NULL,
  `Cedula_Cliente` varchar(8) NOT NULL,
  `ID_Usuario` int(11) NOT NULL,
  `Baja` int(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `celulares`
--

INSERT INTO `celulares` (`ID`, `Localidad`, `ModeloYOmarca`, `IMEI`, `Estado`, `Ingreso`, `Plazo`, `Detalles`, `Presupuesto`, `Adelanto`, `Cedula_Cliente`, `ID_Usuario`, `Baja`) VALUES
(1, '', 'Xaiomi Redmi 9C', '', 'Arreglado', '2023-11-01', '2023-11-01', 'Los botones laterales de suibr y bajar volúmen aparte del de apagar, no funcionan muy bien,, hay que hacer fuerza para que anden. A veces la pantalla no responde al táctil, el cliente nos mencionó que al suceder esto, tiene que apagarlo y prenderlo (bloquéandolo y desbloqueándolo).                                      Problemas solucionados.', '$0', '$850', '87654321', 2, 0),
(2, '', 'Samsung S20', '', 'En Proceso', '2023-11-16', '2023-11-13', '.', '$3500', '$', '90123456', 2, 0),
(3, '', '4', NULL, 'Averiado', '2023-11-03', '2023-11-03', 'ojo', '$', '$', '12234567', 2, 1),
(4, '', 'IPhone XI', '', 'En Proceso', '2023-10-24', '2023-10-24', 'Tiene la pantalla rota y el cristál trasero quebradizo, el puerto de carga no funciona.', '$', '$7500', '12234567', 1, 0),
(5, '', 'Huawei Y6P', '', 'Arreglado', '2023-11-06', '2023-11-09', 'Pantalla rota en las esquinas, le anda bien el táctil. Necesita una limpieza normal.', '$0', '$500', '56782212', 2, 0),
(6, '', 'IPhone 8', '', 'Averiado', '2023-11-13', '2023-11-14', 'le atraveso una bala de tanque calibre 183 que fue disparada en inglaterra por accidente y cayo en una alcantarilla', '$1500', '$3200', '30234567', 1, 0),
(7, '', 'Xiaomi Poco G3', '8965F3R6T423YHG', 'Arreglado', '2023-11-01', '2023-11-01', 'No se sabe.', '$0', '$2500', '28234567', 4, 0),
(8, '', 'Huawei Honor Magic5', '', 'En Espera', '2023-11-13', '2023-11-16', 'Se supone que tendría que responder el cliente, no sabemos si nos dio mal el numero de celular provicional o el correo electronico pero no responde por ninguna de las 2 vias. Una lastima que no podamos contactar por su telefono fijo ya que supuestamente su linea no existe.', '$2500', '$900', '21234567', 3, 0),
(9, '', 'Huawei Y70', '', 'Averiado', '2023-11-13', '2023-11-17', 's', '$', '$', '30234567', 3, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

DROP TABLE IF EXISTS `clientes`;
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
('01234567', 'Isabel González', '47301234', 'isabel.gonzalez@gmail.com', '098012345', 0),
('11234567', 'Manuel Sánchez', '47311234', 'manuel.sanchez@gmail.com', '096112345', 0),
('12234567', 'Carmen Martínez', '47312234', 'carmen.martinez@gmail.com', '097122345', 0),
('12345678', 'Juan Pérez', '47312345', 'juan.perez@gmail.com', '098123456', 0),
('13234567', 'Joaquín Pérez', '47313234', 'joaquin.perez@gmail.com', '098132345', 0),
('14234567', 'Olivia Gómez', '47314234', 'olivia.gomez@gmail.com', '096142345', 0),
('15234567', 'Rodrigo Rodríguez', '47315234', 'rodrigo.rodriguez@gmail.com', '097152345', 0),
('16234567', 'Valentina López', '47316234', 'valentina.lopez@gmail.com', '098162345', 0),
('17234567', 'Daniel Torres', '47317234', 'daniel.torres@gmail.com', '096172345', 0),
('18234567', 'Camila Ramírez', '47318234', 'camila.ramirez@gmail.com', '097182345', 0),
('19234567', 'Andrés Herrera', '47319234', 'andres.herrera@gmail.com', '098192345', 0),
('20234567', 'Mariana Castro', '47320234', 'mariana.castro@gmail.com', '096202345', 0),
('21234567', 'Gustavo Fernández', '47321234', 'gustavo.fernandez@gmail.com', '097212345', 0),
('22234567', 'Carolina González', '47322234', 'carolina.gonzalez@gmail.com', '098222345', 0),
('23234567', 'Eduardo Sánchez', '47323234', 'eduardo.sanchez@gmail.com', '096232345', 0),
('23456789', 'María Gómez', '47323456', 'maria.gomez@gmail.com', '096234567', 0),
('24234567', 'Renata Martínez', '47324234', 'renata.martinez@gmail.com', '097242345', 0),
('25234567', 'Pablo Pérez', '47325234', 'pablo.perez@gmail.com', '098252345', 0),
('26234567', 'Martina Gómez', '47326234', 'martina.gomez@gmail.com', '096262345', 0),
('27234567', 'Fernando Rodríguez', '47327234', 'fernando.rodriguez@gmail.com', '097272345', 0),
('28234567', 'Antonia López', '47328234', 'antonia.lopez@gmail.com', '098282345', 0),
('29234567', 'Emilio Torres', '47329234', 'emilio.torres@gmail.com', '096292345', 0),
('30234567', 'Lucía Ramírez', '47330234', 'lucia.ramirez@gmail.com', '097302345', 0),
('34534555', 'ttyrrtytyr', '', '45y4656456', 'rtyry6535', 0),
('34567890', 'Carlos Rodríguez', '47334567', 'carlos.rodriguez@gmail.com', '097345678', 0),
('45678901', 'Ana López', '47345678', 'ana.lopez@gmail.com', '098456789', 0),
('56782212', 'José Castro', '', 'jc22082007@gmail.com', '096275530', 0),
('56789012', 'Luis Torres', '47356789', 'luis.torres@gmail.com', '096567890', 0),
('67890123', 'Sofía Ramírez', '47367890', 'sofia.ramirez@gmail.com', '097678901', 0),
('68472834', 'Pelada Martinez', '47355576', 'pelada.martinez@outlook.com', '099576234', 0),
('78901234', 'Javier Herrera', '47378901', 'javier.herrera@gmail.com', '098789012', 0),
('87654321', 'Mauricio Gori', '', '', '123456789', 0),
('89012345', 'Laura Castro', '47389012', 'laura.castro@gmail.com', '096890123', 0),
('90123456', 'Diego Fernández', '47390123', 'diego.fernandez@gmail.com', '097901234', 0),
('aaaaaaaa', 'a', 'a', 'a', 'aaaaaaaaa', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sucursales`
--

DROP TABLE IF EXISTS `sucursales`;
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

DROP TABLE IF EXISTS `trabajos`;
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

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
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
(1, 'etech@etech', '4813494d137e1631bba301d5acab6e7bb7aa74ce1185d456565ef51d737677b2', '00000000', 'etech@etech.com', '000000000', 1, 0),
(2, 'sebastian', '5419c560ba0de8c40366cc1691cf77d62db80d820745bca3f4548dc476b4e8db', '', 'seba@gmail.com', '123456789', 1, 0),
(3, 'mauri', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '', 'si@gmail.com', '096275530', 1, 0),
(4, 'José Martinez Gamarra', '6bc01b0b13535eb1e7f6d69b2c0624c51ac5b8ff310c285c880d42e3feca5af0', '', 'equialsJMR@gmail.com', '098999999', 1, 0);

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `sucursales`
--
ALTER TABLE `sucursales`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `trabajos`
--
ALTER TABLE `trabajos`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

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
