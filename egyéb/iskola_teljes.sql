-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Feb 14. 19:26
-- Kiszolgáló verziója: 10.4.24-MariaDB
-- PHP verzió: 8.1.6

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tanarok`
--

CREATE TABLE `tanarok` (
  `id` int(11) NOT NULL,
  `nev` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `tantargy` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `tanarok`
--

INSERT INTO `tanarok` (`id`, `nev`, `email`, `tantargy`) VALUES
(1, 'Bálint Róbert', 'balint.robert@vasvari.org', 'Webprogramozás'),
(2, 'Boros Bence', 'boros.bence@vasvari.org', 'C#'),
(3, 'Dr. Nyári Tibor', 'nyari.tibor@vasvari.org', 'Szoftvertesztelés'),
(4, 'Fanaczán János', 'fanaczan@vasvari.org', 'Játékfejlesztés'),
(5, 'Forgó Gábor', 'forgo.gabor@vasvari.org', 'Hálózati alapok'),
(6, 'Gyuris Csaba', 'gyuris.csaba@vasvari.org', 'C#'),
(7, 'Kádár Tünde', 'kadar.tunde@vasvari.org', 'Adatbázis'),
(8, 'Molnár Edit', 'molnar.edit@vasvari.org', 'Webprogramozás'),
(9, 'Pap Zoltán', 'pap.zoltan@vasvari.org', 'Python'),
(10, 'Rédai Dávid', 'redai.david@vasvari.org', 'Java'),
(11, 'Sebestyén Klára', 'sebestyen.klara@vasvari.org', 'Java'),
(12, 'Szilágyi Zoltán', 'szilagyi.zoltan@vasvari.org', 'Hálózati alapok'),
(13, 'Vastag Atila', 'vastag.atila@vasvari.org', 'Java'),
(14, 'Zsivola Magdolna', 'zsivola@vasvari.org', 'Dokumentumszerkeszté');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vezetoseg`
--

CREATE TABLE `vezetoseg` (
  `id` int(11) NOT NULL,
  `nev` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `megbizas` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `vezetoseg`
--

INSERT INTO `vezetoseg` (`id`, `nev`, `email`, `megbizas`) VALUES
(5, 'Kádár Blanka Julianna', 'kadar.blanka@vasvari.org', 'igazgató'),
(6, 'Dóka Zoltán Béla', 'doka.zoltan@vasvari.org', 'általános igazgatóhelyettes'),
(7, 'Király-Török Annamária', 'kiraly.annamaria@vasvari.org', 'pedagógiai igazgatóhelyettes'),
(8, 'Molnár Edit', 'molnar.edit@vasvari.org', 'szakmai igazgatóhelyettes');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT a táblához `vezetoseg`
--
ALTER TABLE `vezetoseg`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
