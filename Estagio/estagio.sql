-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: 10-Abr-2022 às 22:01
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
-- Estrutura da tabela `ativacao`
--

CREATE TABLE `ativacao` (
  `id` int(11) NOT NULL,
  `keyCode` varchar(50) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `ativacao`
--

INSERT INTO `ativacao` (`id`, `keyCode`, `status`) VALUES
(1, 'ZRUvjkOvB6rlJyjfYNnos050Y5Ym9cpY863QtbHhcLhXVwpjK6', 2),
(2, 'EcGHauEAzA6DE40N5Sg61kZqh7pnbRAztOt8U8vWRR7QZZbEYC', 0),
(3, 'YWJN5N2CCHTil5H5VMFrJSH57124SRpSoliEHLG6bHFWstY7Ta', 0),
(4, 'jq38cZwkFGK988EMHYFPdvebi04aQXp1PMYh4l5biwjZblO8K6', 0),
(5, '5HNSh2uhqjKatpwQxsbQXYlpN7LCoAcb2hzDHHwJW7p1oRtZ72', 0);

-- --------------------------------------------------------

--
-- Estrutura da tabela `estagiodias`
--

CREATE TABLE `estagiodias` (
  `id` int(11) NOT NULL,
  `data` date NOT NULL,
  `descricao` text NOT NULL,
  `horaIni` time NOT NULL,
  `horaFin` time NOT NULL,
  `idAluno` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `estagiodias`
--

INSERT INTO `estagiodias` (`id`, `data`, `descricao`, `horaIni`, `horaFin`, `idAluno`) VALUES
(1, '2022-04-04', 'segunda - recolhemos notebook das salas', '13:00:00', '13:50:00', 1),
(2, '2022-04-04', 'segunda - recolher notebooks', '16:40:00', '17:30:00', 1),
(3, '2022-04-06', 'quarta - montamos o laboratorio 4', '13:00:00', '17:30:00', 1),
(4, '2022-04-08', 'sexta - ajustes no laboratorio 4, criamos um cartaz para irma', '13:00:00', '17:30:00', 1),
(5, '2022-04-10', 'teste', '13:24:00', '15:24:00', 2),
(6, '2022-04-10', 'teste', '13:24:00', '17:24:00', 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `horas`
--

CREATE TABLE `horas` (
  `id` int(11) NOT NULL,
  `total` time NOT NULL,
  `idAluno` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `horas`
--

INSERT INTO `horas` (`id`, `total`, `idAluno`) VALUES
(1, '11:40:00', 1),
(2, '06:00:00', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ativacao`
--
ALTER TABLE `ativacao`
  ADD PRIMARY KEY (`id`);

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
-- AUTO_INCREMENT for table `ativacao`
--
ALTER TABLE `ativacao`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `estagiodias`
--
ALTER TABLE `estagiodias`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `horas`
--
ALTER TABLE `horas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
