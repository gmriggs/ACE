-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.3.15-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping structure for table ace_world.treasure_gem_count
DROP TABLE IF EXISTS `treasure_gem_count`;
CREATE TABLE IF NOT EXISTS `treasure_gem_count` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `gem_Code` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `tier` int(11) NOT NULL,
  `count` int(11) NOT NULL,
  `chance` float NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=487 DEFAULT CHARSET=utf16;

-- Dumping data for table ace_world.treasure_gem_count: ~8 rows (approximately)
/*!40000 ALTER TABLE `treasure_gem_count` DISABLE KEYS */;
INSERT INTO `treasure_gem_count` (`id`, `gem_Code`, `tier`, `count`, `chance`) VALUES
	(1, 1, 1, 0, 1),
	(2, 1, 1, 1, 0),
	(3, 1, 1, 2, 0),
	(4, 1, 1, 3, 0),
	(5, 1, 1, 4, 0),
	(6, 1, 1, 5, 0),
	(7, 1, 1, 6, 0),
	(8, 1, 1, 7, 0),
	(9, 1, 1, 8, 0),
	(10, 1, 2, 0, 1),
	(11, 1, 2, 1, 0),
	(12, 1, 2, 2, 0),
	(13, 1, 2, 3, 0),
	(14, 1, 2, 4, 0),
	(15, 1, 2, 5, 0),
	(16, 1, 2, 6, 0),
	(17, 1, 2, 7, 0),
	(18, 1, 2, 8, 0),
	(19, 1, 3, 0, 1),
	(20, 1, 3, 1, 0),
	(21, 1, 3, 2, 0),
	(22, 1, 3, 3, 0),
	(23, 1, 3, 4, 0),
	(24, 1, 3, 5, 0),
	(25, 1, 3, 6, 0),
	(26, 1, 3, 7, 0),
	(27, 1, 3, 8, 0),
	(28, 1, 4, 0, 1),
	(29, 1, 4, 1, 0),
	(30, 1, 4, 2, 0),
	(31, 1, 4, 3, 0),
	(32, 1, 4, 4, 0),
	(33, 1, 4, 5, 0),
	(34, 1, 4, 6, 0),
	(35, 1, 4, 7, 0),
	(36, 1, 4, 8, 0),
	(37, 1, 5, 0, 1),
	(38, 1, 5, 1, 0),
	(39, 1, 5, 2, 0),
	(40, 1, 5, 3, 0),
	(41, 1, 5, 4, 0),
	(42, 1, 5, 5, 0),
	(43, 1, 5, 6, 0),
	(44, 1, 5, 7, 0),
	(45, 1, 5, 8, 0),
	(46, 1, 6, 0, 1),
	(47, 1, 6, 1, 0),
	(48, 1, 6, 2, 0),
	(49, 1, 6, 3, 0),
	(50, 1, 6, 4, 0),
	(51, 1, 6, 5, 0),
	(52, 1, 6, 6, 0),
	(53, 1, 6, 7, 0),
	(54, 1, 6, 8, 0),
	(55, 2, 1, 0, 1),
	(56, 2, 1, 1, 0),
	(57, 2, 1, 2, 0),
	(58, 2, 1, 3, 0),
	(59, 2, 1, 4, 0),
	(60, 2, 1, 5, 0),
	(61, 2, 1, 6, 0),
	(62, 2, 1, 7, 0),
	(63, 2, 1, 8, 0),
	(64, 2, 2, 0, 0.9),
	(65, 2, 2, 1, 0.1),
	(66, 2, 2, 2, 0),
	(67, 2, 2, 3, 0),
	(68, 2, 2, 4, 0),
	(69, 2, 2, 5, 0),
	(70, 2, 2, 6, 0),
	(71, 2, 2, 7, 0),
	(72, 2, 2, 8, 0),
	(73, 2, 3, 0, 0.75),
	(74, 2, 3, 1, 0.25),
	(75, 2, 3, 2, 0),
	(76, 2, 3, 3, 0),
	(77, 2, 3, 4, 0),
	(78, 2, 3, 5, 0),
	(79, 2, 3, 6, 0),
	(80, 2, 3, 7, 0),
	(81, 2, 3, 8, 0),
	(82, 2, 4, 0, 0.5),
	(83, 2, 4, 1, 0.5),
	(84, 2, 4, 2, 0),
	(85, 2, 4, 3, 0),
	(86, 2, 4, 4, 0),
	(87, 2, 4, 5, 0),
	(88, 2, 4, 6, 0),
	(89, 2, 4, 7, 0),
	(90, 2, 4, 8, 0),
	(91, 2, 5, 0, 0.2),
	(92, 2, 5, 1, 0.8),
	(93, 2, 5, 2, 0),
	(94, 2, 5, 3, 0),
	(95, 2, 5, 4, 0),
	(96, 2, 5, 5, 0),
	(97, 2, 5, 6, 0),
	(98, 2, 5, 7, 0),
	(99, 2, 5, 8, 0),
	(100, 2, 6, 0, 0),
	(101, 2, 6, 1, 1),
	(102, 2, 6, 2, 0),
	(103, 2, 6, 3, 0),
	(104, 2, 6, 4, 0),
	(105, 2, 6, 5, 0),
	(106, 2, 6, 6, 0),
	(107, 2, 6, 7, 0),
	(108, 2, 6, 8, 0),
	(109, 3, 1, 0, 0),
	(110, 3, 1, 1, 1),
	(111, 3, 1, 2, 0),
	(112, 3, 1, 3, 0),
	(113, 3, 1, 4, 0),
	(114, 3, 1, 5, 0),
	(115, 3, 1, 6, 0),
	(116, 3, 1, 7, 0),
	(117, 3, 1, 8, 0),
	(118, 3, 2, 0, 0),
	(119, 3, 2, 1, 1),
	(120, 3, 2, 2, 0),
	(121, 3, 2, 3, 0),
	(122, 3, 2, 4, 0),
	(123, 3, 2, 5, 0),
	(124, 3, 2, 6, 0),
	(125, 3, 2, 7, 0),
	(126, 3, 2, 8, 0),
	(127, 3, 3, 0, 0),
	(128, 3, 3, 1, 1),
	(129, 3, 3, 2, 0),
	(130, 3, 3, 3, 0),
	(131, 3, 3, 4, 0),
	(132, 3, 3, 5, 0),
	(133, 3, 3, 6, 0),
	(134, 3, 3, 7, 0),
	(135, 3, 3, 8, 0),
	(136, 3, 4, 0, 0),
	(137, 3, 4, 1, 1),
	(138, 3, 4, 2, 0),
	(139, 3, 4, 3, 0),
	(140, 3, 4, 4, 0),
	(141, 3, 4, 5, 0),
	(142, 3, 4, 6, 0),
	(143, 3, 4, 7, 0),
	(144, 3, 4, 8, 0),
	(145, 3, 5, 0, 0),
	(146, 3, 5, 1, 1),
	(147, 3, 5, 2, 0),
	(148, 3, 5, 3, 0),
	(149, 3, 5, 4, 0),
	(150, 3, 5, 5, 0),
	(151, 3, 5, 6, 0),
	(152, 3, 5, 7, 0),
	(153, 3, 5, 8, 0),
	(154, 3, 6, 0, 0),
	(155, 3, 6, 1, 1),
	(156, 3, 6, 2, 0),
	(157, 3, 6, 3, 0),
	(158, 3, 6, 4, 0),
	(159, 3, 6, 5, 0),
	(160, 3, 6, 6, 0),
	(161, 3, 6, 7, 0),
	(162, 3, 6, 8, 0),
	(163, 4, 1, 0, 1),
	(164, 4, 1, 1, 0),
	(165, 4, 1, 2, 0),
	(166, 4, 1, 3, 0),
	(167, 4, 1, 4, 0),
	(168, 4, 1, 5, 0),
	(169, 4, 1, 6, 0),
	(170, 4, 1, 7, 0),
	(171, 4, 1, 8, 0),
	(172, 4, 2, 0, 0.85),
	(173, 4, 2, 1, 0.1),
	(174, 4, 2, 2, 0.05),
	(175, 4, 2, 3, 0),
	(176, 4, 2, 4, 0),
	(177, 4, 2, 5, 0),
	(178, 4, 2, 6, 0),
	(179, 4, 2, 7, 0),
	(180, 4, 2, 8, 0),
	(181, 4, 3, 0, 0.7),
	(182, 4, 3, 1, 0.2),
	(183, 4, 3, 2, 0.1),
	(184, 4, 3, 3, 0),
	(185, 4, 3, 4, 0),
	(186, 4, 3, 5, 0),
	(187, 4, 3, 6, 0),
	(188, 4, 3, 7, 0),
	(189, 4, 3, 8, 0),
	(190, 4, 4, 0, 0.4),
	(191, 4, 4, 1, 0.4),
	(192, 4, 4, 2, 0.2),
	(193, 4, 4, 3, 0),
	(194, 4, 4, 4, 0),
	(195, 4, 4, 5, 0),
	(196, 4, 4, 6, 0),
	(197, 4, 4, 7, 0),
	(198, 4, 4, 8, 0),
	(199, 4, 5, 0, 0.1),
	(200, 4, 5, 1, 0.5),
	(201, 4, 5, 2, 0.4),
	(202, 4, 5, 3, 0),
	(203, 4, 5, 4, 0),
	(204, 4, 5, 5, 0),
	(205, 4, 5, 6, 0),
	(206, 4, 5, 7, 0),
	(207, 4, 5, 8, 0),
	(208, 4, 6, 0, 0),
	(209, 4, 6, 1, 0.25),
	(210, 4, 6, 2, 0.75),
	(211, 4, 6, 3, 0),
	(212, 4, 6, 4, 0),
	(213, 4, 6, 5, 0),
	(214, 4, 6, 6, 0),
	(215, 4, 6, 7, 0),
	(216, 4, 6, 8, 0),
	(217, 5, 1, 0, 1),
	(218, 5, 1, 1, 0),
	(219, 5, 1, 2, 0),
	(220, 5, 1, 3, 0),
	(221, 5, 1, 4, 0),
	(222, 5, 1, 5, 0),
	(223, 5, 1, 6, 0),
	(224, 5, 1, 7, 0),
	(225, 5, 1, 8, 0),
	(226, 5, 2, 0, 0.9),
	(227, 5, 2, 1, 0),
	(228, 5, 2, 2, 0.1),
	(229, 5, 2, 3, 0),
	(230, 5, 2, 4, 0),
	(231, 5, 2, 5, 0),
	(232, 5, 2, 6, 0),
	(233, 5, 2, 7, 0),
	(234, 5, 2, 8, 0),
	(235, 5, 3, 0, 0.75),
	(236, 5, 3, 1, 0),
	(237, 5, 3, 2, 0.25),
	(238, 5, 3, 3, 0),
	(239, 5, 3, 4, 0),
	(240, 5, 3, 5, 0),
	(241, 5, 3, 6, 0),
	(242, 5, 3, 7, 0),
	(243, 5, 3, 8, 0),
	(244, 5, 4, 0, 0.5),
	(245, 5, 4, 1, 0),
	(246, 5, 4, 2, 0.5),
	(247, 5, 4, 3, 0),
	(248, 5, 4, 4, 0),
	(249, 5, 4, 5, 0),
	(250, 5, 4, 6, 0),
	(251, 5, 4, 7, 0),
	(252, 5, 4, 8, 0),
	(253, 5, 5, 0, 0.2),
	(254, 5, 5, 1, 0),
	(255, 5, 5, 2, 0.8),
	(256, 5, 5, 3, 0),
	(257, 5, 5, 4, 0),
	(258, 5, 5, 5, 0),
	(259, 5, 5, 6, 0),
	(260, 5, 5, 7, 0),
	(261, 5, 5, 8, 0),
	(262, 5, 6, 0, 0),
	(263, 5, 6, 1, 0),
	(264, 5, 6, 2, 1),
	(265, 5, 6, 3, 0),
	(266, 5, 6, 4, 0),
	(267, 5, 6, 5, 0),
	(268, 5, 6, 6, 0),
	(269, 5, 6, 7, 0),
	(270, 5, 6, 8, 0),
	(271, 6, 1, 0, 1),
	(272, 6, 1, 1, 0),
	(273, 6, 1, 2, 0),
	(274, 6, 1, 3, 0),
	(275, 6, 1, 4, 0),
	(276, 6, 1, 5, 0),
	(277, 6, 1, 6, 0),
	(278, 6, 1, 7, 0),
	(279, 6, 1, 8, 0),
	(280, 6, 2, 0, 0.85),
	(281, 6, 2, 1, 0.1),
	(282, 6, 2, 2, 0.05),
	(283, 6, 2, 3, 0),
	(284, 6, 2, 4, 0),
	(285, 6, 2, 5, 0),
	(286, 6, 2, 6, 0),
	(287, 6, 2, 7, 0),
	(288, 6, 2, 8, 0),
	(289, 6, 3, 0, 0.6),
	(290, 6, 3, 1, 0.25),
	(291, 6, 3, 2, 0.1),
	(292, 6, 3, 3, 0.05),
	(293, 6, 3, 4, 0),
	(294, 6, 3, 5, 0),
	(295, 6, 3, 6, 0),
	(296, 6, 3, 7, 0),
	(297, 6, 3, 8, 0),
	(298, 6, 4, 0, 0.3),
	(299, 6, 4, 1, 0.3),
	(300, 6, 4, 2, 0.25),
	(301, 6, 4, 3, 0.15),
	(302, 6, 4, 4, 0),
	(303, 6, 4, 5, 0),
	(304, 6, 4, 6, 0),
	(305, 6, 4, 7, 0),
	(306, 6, 4, 8, 0),
	(307, 6, 5, 0, 0.1),
	(308, 6, 5, 1, 0.25),
	(309, 6, 5, 2, 0.3),
	(310, 6, 5, 3, 0.35),
	(311, 6, 5, 4, 0),
	(312, 6, 5, 5, 0),
	(313, 6, 5, 6, 0),
	(314, 6, 5, 7, 0),
	(315, 6, 5, 8, 0),
	(316, 6, 6, 0, 0),
	(317, 6, 6, 1, 0.15),
	(318, 6, 6, 2, 0.35),
	(319, 6, 6, 3, 0.5),
	(320, 6, 6, 4, 0),
	(321, 6, 6, 5, 0),
	(322, 6, 6, 6, 0),
	(323, 6, 6, 7, 0),
	(324, 6, 6, 8, 0),
	(325, 7, 1, 0, 1),
	(326, 7, 1, 1, 0),
	(327, 7, 1, 2, 0),
	(328, 7, 1, 3, 0),
	(329, 7, 1, 4, 0),
	(330, 7, 1, 5, 0),
	(331, 7, 1, 6, 0),
	(332, 7, 1, 7, 0),
	(333, 7, 1, 8, 0),
	(334, 7, 2, 0, 0.85),
	(335, 7, 2, 1, 0.1),
	(336, 7, 2, 2, 0.05),
	(337, 7, 2, 3, 0),
	(338, 7, 2, 4, 0),
	(339, 7, 2, 5, 0),
	(340, 7, 2, 6, 0),
	(341, 7, 2, 7, 0),
	(342, 7, 2, 8, 0),
	(343, 7, 3, 0, 0.6),
	(344, 7, 3, 1, 0.25),
	(345, 7, 3, 2, 0.1),
	(346, 7, 3, 3, 0.05),
	(347, 7, 3, 4, 0),
	(348, 7, 3, 5, 0),
	(349, 7, 3, 6, 0),
	(350, 7, 3, 7, 0),
	(351, 7, 3, 8, 0),
	(352, 7, 4, 0, 0.25),
	(353, 7, 4, 1, 0.3),
	(354, 7, 4, 2, 0.25),
	(355, 7, 4, 3, 0.15),
	(356, 7, 4, 4, 0.05),
	(357, 7, 4, 5, 0),
	(358, 7, 4, 6, 0),
	(359, 7, 4, 7, 0),
	(360, 7, 4, 8, 0),
	(361, 7, 5, 0, 0.1),
	(362, 7, 5, 1, 0.2),
	(363, 7, 5, 2, 0.2),
	(364, 7, 5, 3, 0.3),
	(365, 7, 5, 4, 0.2),
	(366, 7, 5, 5, 0),
	(367, 7, 5, 6, 0),
	(368, 7, 5, 7, 0),
	(369, 7, 5, 8, 0),
	(370, 7, 6, 0, 0),
	(371, 7, 6, 1, 0.1),
	(372, 7, 6, 2, 0.2),
	(373, 7, 6, 3, 0.2),
	(374, 7, 6, 4, 0.5),
	(375, 7, 6, 5, 0),
	(376, 7, 6, 6, 0),
	(377, 7, 6, 7, 0),
	(378, 7, 6, 8, 0),
	(379, 8, 1, 0, 0.7),
	(380, 8, 1, 1, 0.25),
	(381, 8, 1, 2, 0.05),
	(382, 8, 1, 3, 0),
	(383, 8, 1, 4, 0),
	(384, 8, 1, 5, 0),
	(385, 8, 1, 6, 0),
	(386, 8, 1, 7, 0),
	(387, 8, 1, 8, 0),
	(388, 8, 2, 0, 0.7),
	(389, 8, 2, 1, 0.25),
	(390, 8, 2, 2, 0.05),
	(391, 8, 2, 3, 0),
	(392, 8, 2, 4, 0),
	(393, 8, 2, 5, 0),
	(394, 8, 2, 6, 0),
	(395, 8, 2, 7, 0),
	(396, 8, 2, 8, 0),
	(397, 8, 3, 0, 0.15),
	(398, 8, 3, 1, 0.2),
	(399, 8, 3, 2, 0.2),
	(400, 8, 3, 3, 0.3),
	(401, 8, 3, 4, 0.15),
	(402, 8, 3, 5, 0),
	(403, 8, 3, 6, 0),
	(404, 8, 3, 7, 0),
	(405, 8, 3, 8, 0),
	(406, 8, 4, 0, 0.15),
	(407, 8, 4, 1, 0.2),
	(408, 8, 4, 2, 0.2),
	(409, 8, 4, 3, 0.3),
	(410, 8, 4, 4, 0.15),
	(411, 8, 4, 5, 0),
	(412, 8, 4, 6, 0),
	(413, 8, 4, 7, 0),
	(414, 8, 4, 8, 0),
	(415, 8, 5, 0, 0),
	(416, 8, 5, 1, 0),
	(417, 8, 5, 2, 0.1),
	(418, 8, 5, 3, 0.2),
	(419, 8, 5, 4, 0.2),
	(420, 8, 5, 5, 0.25),
	(421, 8, 5, 6, 0.25),
	(422, 8, 5, 7, 0),
	(423, 8, 5, 8, 0),
	(424, 8, 6, 0, 0),
	(425, 8, 6, 1, 0),
	(426, 8, 6, 2, 0.1),
	(427, 8, 6, 3, 0.2),
	(428, 8, 6, 4, 0.2),
	(429, 8, 6, 5, 0.25),
	(430, 8, 6, 6, 0.25),
	(431, 8, 6, 7, 0),
	(432, 8, 6, 8, 0),
	(433, 9, 1, 0, 1),
	(434, 9, 1, 1, 0),
	(435, 9, 1, 2, 0),
	(436, 9, 1, 3, 0),
	(437, 9, 1, 4, 0),
	(438, 9, 1, 5, 0),
	(439, 9, 1, 6, 0),
	(440, 9, 1, 7, 0),
	(441, 9, 1, 8, 0),
	(442, 9, 2, 0, 0.85),
	(443, 9, 2, 1, 0.1),
	(444, 9, 2, 2, 0.05),
	(445, 9, 2, 3, 0),
	(446, 9, 2, 4, 0),
	(447, 9, 2, 5, 0),
	(448, 9, 2, 6, 0),
	(449, 9, 2, 7, 0),
	(450, 9, 2, 8, 0),
	(451, 9, 3, 0, 0.15),
	(452, 9, 3, 1, 0.2),
	(453, 9, 3, 2, 0.2),
	(454, 9, 3, 3, 0.3),
	(455, 9, 3, 4, 0.15),
	(456, 9, 3, 5, 0),
	(457, 9, 3, 6, 0),
	(458, 9, 3, 7, 0),
	(459, 9, 3, 8, 0),
	(460, 9, 4, 0, 0.6),
	(461, 9, 4, 1, 0.25),
	(462, 9, 4, 2, 0.1),
	(463, 9, 4, 3, 0.05),
	(464, 9, 4, 4, 0),
	(465, 9, 4, 5, 0),
	(466, 9, 4, 6, 0),
	(467, 9, 4, 7, 0),
	(468, 9, 4, 8, 0),
	(469, 9, 5, 0, 0),
	(470, 9, 5, 1, 0),
	(471, 9, 5, 2, 0.25),
	(472, 9, 5, 3, 0.25),
	(473, 9, 5, 4, 0.25),
	(474, 9, 5, 5, 0.25),
	(475, 9, 5, 6, 0),
	(476, 9, 5, 7, 0),
	(477, 9, 5, 8, 0),
	(478, 9, 6, 0, 0),
	(479, 9, 6, 1, 0),
	(480, 9, 6, 2, 0),
	(481, 9, 6, 3, 0.1),
	(482, 9, 6, 4, 0.1),
	(483, 9, 6, 5, 0.2),
	(484, 9, 6, 6, 0.2),
	(485, 9, 6, 7, 0.2),
	(486, 9, 6, 8, 0.2);
/*!40000 ALTER TABLE `treasure_gem_count` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
