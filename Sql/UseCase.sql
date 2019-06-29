/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 80013
Source Host           : localhost:3306
Source Database       : gogogo

Target Server Type    : MYSQL
Target Server Version : 80013
File Encoding         : 65001

Date: 2019-06-29 16:14:01
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for usecase
-- ----------------------------
DROP TABLE IF EXISTS `usecase`;
CREATE TABLE `usecase` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `product_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `module_id` bigint(20) NOT NULL,
  `creator_id` bigint(20) unsigned NOT NULL,
  `last_editor_id` bigint(20) NOT NULL DEFAULT '0',
  `test_path` varchar(255) DEFAULT NULL,
  `remark` text,
  `paramas` text,
  `expected_results` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `tested_results` text NOT NULL,
  `quality_pass` bit(1) NOT NULL DEFAULT b'0',
  `state` int(4) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of usecase
-- ----------------------------
