/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 80013
Source Host           : localhost:3306
Source Database       : gogogo

Target Server Type    : MYSQL
Target Server Version : 80013
File Encoding         : 65001

Date: 2019-06-19 15:27:46
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for productversion
-- ----------------------------
DROP TABLE IF EXISTS `productversion`;
CREATE TABLE `productversion` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `version_code` varchar(255) NOT NULL,
  `product_id` bigint(20) NOT NULL DEFAULT '0',
  `creator_id` bigint(20) NOT NULL DEFAULT '0',
  `remark` text NOT NULL,
  `level` int(4) NOT NULL,
  `state` int(4) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of productversion
-- ----------------------------
