/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 80013
Source Host           : localhost:3306
Source Database       : gogogo

Target Server Type    : MYSQL
Target Server Version : 80013
File Encoding         : 65001

Date: 2019-06-17 16:56:33
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for productmodule
-- ----------------------------
DROP TABLE IF EXISTS `productmodule`;
CREATE TABLE `productmodule` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `product_id` bigint(20) NOT NULL DEFAULT '0',
  `module_code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `creator_id` bigint(20) unsigned NOT NULL,
  `last_editor_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `iteration_number` bigint(20) unsigned NOT NULL DEFAULT '0',
  `parent_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `title` varchar(255) NOT NULL,
  `remark` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `level` int(4) NOT NULL DEFAULT '0',
  `state` int(4) NOT NULL DEFAULT '0',
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of productmodule
-- ----------------------------
