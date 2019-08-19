<template>
	<div class="login-page">
		<div class="login-box">
			<div class="box-top">
				<h3>GOGOGO登录</h3>
			</div>
			<el-form ref="formData" :model="formData">
				<el-form-item prop="userName" :rules="[{ required: true, message: '', trigger: 'blur' }]">
					<el-input v-model="formData.userName" prefix-icon="el-icon-user" maxlength="16"></el-input>
				</el-form-item>
				<el-form-item prop="password" required>
					<el-input
						v-model="formData.password"
						type="password"
						prefix-icon="el-icon-lock"
						maxlength="16"
					></el-input>
				</el-form-item>
				<el-form-item>
					<el-button type="primary" class="btn-block" :loading="submiting" @click="handleLogin">登录</el-button>
				</el-form-item>
			</el-form>
		</div>
	</div>
</template>

<script>
	import { loginSubmit } from "@/api/login";

	export default {
		data() {
			return {
				formData: {},
				submiting: false
			};
		},
		mounted() {
			console.log(process.env);
			if (process.env.NODE_ENV === "development") {
				this.formData = {
					userName: "admin",
					password: "123456"
				};
			}
		},
		methods: {
			handleLogin() {
				this.$router.push({ name: "home" });
				// this.$refs["formData"].validate(valid => {
				// 	if (valid) {
				// 		this.submiting = true;
				// 		loginSubmit(this.formData)
				// 			.then(result => {
				// 				this.$router.push({ name: "home" });
				// 			})
				// 			.catch(err => {
				// 				this.$message.error("用户名或密码错误");
				// 			})
				// 			.then(() => {
				// 				this.submiting = false;
				// 			});
				// 	}
				// });
			}
		}
	};
</script>

<style lang="less" scoped>
	.login-page {
		background-image: url(../../assets/images/login-bg.svg);
		background-repeat: no-repeat;
		background-position: 50%;
		background-size: 100%;
		display: flex;
		flex-direction: column;
		height: 100vh;
		overflow: auto;

		.login-box {
			text-align: center;
			width: 384px;
			margin: 0 auto;
			margin-top: 150px;
		}
	}
</style>