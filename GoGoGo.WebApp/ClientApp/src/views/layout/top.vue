<template>
	<div class="clearfix">
		<div class="pull-right clearfix">
			<div class="item item-user">
				<el-avatar icon="el-icon-user-solid" size="small"></el-avatar>
				<el-dropdown @command="handleUserMenuSelect">
					<!-- <span>
						<el-avatar :size="30">U</el-avatar>
						<span>{{userInfo.name}}</span> 
					</span>-->
					<span class="el-dropdown-link">
						<!-- <i class="el-icon-user"></i> -->

						<span>{{userInfo.name}}</span>
						<i class="el-icon-arrow-down el-icon--right"></i>
					</span>
					<el-dropdown-menu slot="dropdown">
						<el-dropdown-item command="changepassword">修改密码</el-dropdown-item>
						<el-dropdown-item divided command="logout">退出</el-dropdown-item>
					</el-dropdown-menu>
				</el-dropdown>
			</div>
		</div>
	</div>
</template>

<script>
	import signalR, { HubConnectionBuilder, LogLevel } from "@aspnet/signalr";

	import { mapActions } from "vuex";

	export default {
		data() {
			return {
				token: this.$store.state.token
			};
		},

		computed: {
			userInfo() {
				return this.$store.state.user;
			}
		},

		mounted() {},

		destroyed() {},

		methods: {
			...mapActions(["clearToken"]),
			handleUserMenuSelect(command) {
				// console.log(command);
				if (command === "logout") {
					this.clearToken()
						.then(result => {
							this.$router.replace({ name: "login" });
						})
						.catch(err => {});
				} else if (command === "changepassword") {
					this.$router.push({ name: "changePassword" });
				}
			}
		},
		watch: {}
	};
</script>

<style lang="less"  >
	.table2 {
		width: 100%;
		border-collapse: collapse;
		border: 1px solid #e8e8e8;

		th,
		td {
			border: 1px solid #e8e8e8;
			padding: 3px 5px;
		}
	}

	.tooltip-content {
		max-width: 450px;
		word-wrap: break-word;
	}
</style>