-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Okt 16. 11:54
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `iskola`
--
CREATE DATABASE IF NOT EXISTS `iskola` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `iskola`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `diakok`
--

CREATE TABLE `diakok` (
  `id` int(11) NOT NULL,
  `nev` varchar(50) NOT NULL,
  `email` varchar(22) NOT NULL,
  `erdemjegy` smallint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `diakok`
--

INSERT INTO `diakok` (`id`, `nev`, `email`, `erdemjegy`) VALUES
(1, 'Csóti István', 'bsze3csoist@vasvari.or', 4),
(2, 'Erdélyi Dávid', 'bsze3erddav@vasvari.or', 5),
(3, 'Grezsa Zoltán Gábor', 'bsze3grezol@vasvari.or', 5),
(4, 'Guba Viktor', 'bsze3gubvik@vasvari.or', 1),
(5, 'Horváth Péter', 'bsze3horpet@vasvari.or', 2),
(6, 'Huszka Leila Renáta', 'bsze3huslei@vasvari.or', 5),
(7, 'Kopincu Máté', 'bsze3kopmat@vasvari.or', 1),
(8, 'Kovács József Miklós', 'bsze3kovjoz@vasvari.or', 5),
(9, 'Lajkó Levente', 'bsze3lajlev@vasvari.or', 4),
(10, 'Márkus Netti Teodóra', 'bsze3marnet@vasvari.or', 4),
(11, 'Molnár Edit', 'molnar.edit@vasvari.or', 2),
(12, 'Pécsi Bianka', 'bsze3pecbia@vasvari.or', 2),
(13, 'Simon Gábor', 'bsze3simgab@vasvari.or', 4),
(14, 'Székely Levente', 'bsze3szelev@vasvari.or', 4),
(15, 'Takács András', 'bsze3takand@vasvari.or', 3),
(16, 'Töröcsik Ákos', 'bsze3torako@vasvari.or', 1),
(17, 'Varga Gábor', 'bsze3vargab@vasvari.or', 2),
(18, 'Wittmann Gyula', 'csze2witgyu@vasvari.or', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tanarok`
--

CREATE TABLE `tanarok` (
  `id` int(11) NOT NULL,
  `nev` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `tantargy` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `tanarok`
--

INSERT INTO `tanarok` (`id`, `nev`, `email`, `tantargy`) VALUES
(1, 'Bálint Róbert', 'balint.robert@vasvari.org', 'Webprogramozás'),
(2, 'Boros Bence', 'boros.bence@vasvari.org', 'C#'),
(3, 'Dr. Nyári Tibor', 'nyari.tibor@vasvari.org', 'Szoftvertesztelés'),
(4, 'Rédai Dávid', 'redai.david@vasvari.org', 'Adatbázis'),
(5, 'Gyuris Csaba', 'gyuris.csaba@vasvari.org', 'C#'),
(7, 'Molnár Edit', 'molnar.edit@vasvari.org', 'Webprogramozás'),
(8, 'Kormányos Antal', 'pap.zoltan@vasvari.org', 'Python'),
(9, 'Sebestyén Klára', 'sebestyen.klara@vasvari.org', 'Java'),
(10, 'Forgó Gábor', 'forgo.gabor@vasvari.org', 'Hálózati alapok'),
(11, 'Zsivola Magdolna', 'zsivola@vasvari.org', 'Dokumentumszerkeszté');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vezetoseg`
--

CREATE TABLE `vezetoseg` (
  `id` int(11) NOT NULL,
  `nev` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `megbizas` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `vezetoseg`
--

INSERT INTO `vezetoseg` (`id`, `nev`, `email`, `megbizas`) VALUES
(1, 'Kádár Blanka Julianna', 'kadar.blanka@vasvari.org', 'igazgató'),
(2, 'Dóka Zoltán Béla', 'doka.zoltan@vasvari.org', 'általános igazgatóhelyettes'),
(3, 'Murár Zoltán', 'murar.zoltan@vasvari.org', 'pedagógiai igazgatóhelyettes'),
(4, 'Molnár Edit', 'molnar.edit@vasvari.org', 'szakmai igazgatóhelyettes');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `diakok`
--
ALTER TABLE `diakok`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `nev` (`nev`);

--
-- A tábla indexei `tanarok`
--
ALTER TABLE `tanarok`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- A tábla indexei `vezetoseg`
--
ALTER TABLE `vezetoseg`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`,`email`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `diakok`
--
ALTER TABLE `diakok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `tanarok`
--
ALTER TABLE `tanarok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT a táblához `vezetoseg`
--
ALTER TABLE `vezetoseg`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
