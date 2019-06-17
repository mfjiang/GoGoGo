/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 80013
Source Host           : localhost:3306
Source Database       : gogogo

Target Server Type    : MYSQL
Target Server Version : 80013
File Encoding         : 65001

Date: 2019-06-17 16:56:17
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for product
-- ----------------------------
DROP TABLE IF EXISTS `product`;
CREATE TABLE `product` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(255) DEFAULT NULL,
  `name` varchar(255) NOT NULL,
  `remark` text NOT NULL,
  `main_ver` varchar(255) NOT NULL,
  `source_uri` varchar(255) DEFAULT NULL,
  `open_api_uri` varchar(255) DEFAULT NULL,
  `creator_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `last_editor_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `level` int(4) NOT NULL DEFAULT '0',
  `state` int(4) NOT NULL,
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of product
-- ----------------------------
