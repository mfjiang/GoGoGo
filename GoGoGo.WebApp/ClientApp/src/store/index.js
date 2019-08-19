import Vue from "vue";
import Vuex from "vuex";

import { getToken, setToken } from "@/libs/";

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        token: getToken(),
        hasUserInfo: false,
        user: {
            name: ""
        }
    },
    mutations: {
        updateUserName(state, value) {
            state.user.name = value;
        },
        setToken(state, value) {
            state.token = value;
            setToken(value);
        },
        setAccessKeys(state, value) {},
        setHasUserInfo(state, value) {
            state.hasUserInfo = value;
        }
    },
    actions: {
        /**
         *  保存token
         * @param {string} token
         */
        saveAccessToken({ commit }, { token }) {
            return new Promise((resolve, reject) => {
                if (token) {
                    commit("setToken", token);
                    commit("setHasUserInfo", false);
                    resolve(token);
                } else {
                    reject();
                }
            });
        },

        /**
         *  清理token
         */
        clearToken({ commit }) {
            return new Promise(resolve => {
                commit("setToken", "");
                commit("setAccessKeys", []);
                commit("setHasUserInfo", false);
                resolve();
            });
        },

        /**
         *  更新当前用户信息
         */
        updateUserInfo({ commit }, { data }) {
            return new Promise(resolve => {
                commit("updateUserName", data.userName);
                // commit("updateUserName", data.displayName);
                commit("setAccessKeys", []);
                commit("setHasUserInfo", true);
                resolve(data);
            });
        }
    }
});
