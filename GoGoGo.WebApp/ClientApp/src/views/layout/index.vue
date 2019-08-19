<template>
	<el-container id="main">
		<!-- <el-aside width="260px" id="main-left">
			<div class="left-top">GOGOGO</div>
			<left-menu :data="menus" @menuSelect="handleMenuSelect"></left-menu>
		</el-aside>-->
		<el-container>
			<el-header id="main-top">
				<top></top>
			</el-header>
			<el-main id="main-content">
				<router-view></router-view>
			</el-main>
		</el-container>
	</el-container>
</template>
 
 <script>
	import LeftMenu from "./menu";
	import Top from "./top";

	import routeConfig from "@/router/config";
	import menuConfig from "@/config/menu";

	import { resolveMenuFromRoutes } from "@/libs/";

	export default {
		components: { LeftMenu, Top },
		data() {
			return {
				menus: []
			};
		},
		created() {
			console.log(process.env);
		},
		mounted() {
			this.menus = menuConfig;
		},
		methods: {
			handleMenuSelect(index) {
				// console.log(index);
				this.$router.push({ name: index });
			}
		}
	};
</script>
  
 <style lang="less">
	#main {
		height: 100%;

		#main-left {
			height: 100%;
			background-color: rgb(84, 92, 100);

			.left-top {
				height: 30px;
				text-align: center;
				color: #fff;
				padding: 15px;
				line-height: 30px;
			}

			.el-menu {
				// height: 100%;
			}
		}

		#main-top {
			padding: 12px 14px;
			box-shadow: rgba(0, 0, 0, 0.1) 0px 2px 3px 2px;

			.item {
				float: left;
				margin-left: 10px;
				line-height: 32px;
			}

			.item-user {
				line-height: 32px;
				span {
					vertical-align: bottom;
					display: inline-block;
				}
				.el-avatar {
					width: 31px;
					height: 31px;
					margin-right: 6px;
				}
			}
		}

		#main-content {
			background: #f0f2f5;
		}
	}
</style>
 