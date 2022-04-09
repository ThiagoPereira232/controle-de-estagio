-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: 09-Abr-2022 às 01:13
-- Versão do servidor: 5.7.25
-- versão do PHP: 7.1.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `estagio`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `estagiodias`
--

CREATE TABLE `estagiodias` (
  `id` int(11) NOT NULL,
  `data` date NOT NULL,
  `descricao` text NOT NULL,
  `horaIni` time NOT NULL,
  `horaFin` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `estagiodias`
--

INSERT INTO `estagiodias` (`id`, `data`, `descricao`, `horaIni`, `horaFin`) VALUES
(1, '2022-04-04', 'segunda - recolhemos notebook das salas', '13:00:00', '13:50:00'),
(2, '2022-04-04', 'segunda - recolher notebooks', '16:40:00', '17:30:00'),
(3, '2022-04-06', 'quarta - montamos o laboratorio 4', '13:00:00', '17:30:00'),
(4, '2022-04-08', 'sexta - ajustes no laboratorio 4, criamos um cartaz para irma', '13:00:00', '17:30:00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `horas`
--

CREATE TABLE `horas` (
  `id` int(11) NOT NULL,
  `total` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `horas`
--

INSERT INTO `horas` (`id`, `total`) VALUES
(1, '10:40:00');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `estagiodias`
--
ALTER TABLE `estagiodias`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `horas`
--
ALTER TABLE `horas`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `estagiodias`
--
ALTER TABLE `estagiodias`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `horas`
--
ALTER TABLE `horas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
