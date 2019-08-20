import http from "../libs/http";
import store from "../store";

export const loginSubmit = payload => {
    return new Promise(function(resolve, reject) {
        http.post("api/auth/token", payload)
            .then(result => {
                if (result.data) {
                    // console.log(result.data);
                    store.dispatch("saveAccessToken", { token: result.data.token });
                    store.dispatch("updateUserInfo", { data: result.data });
                    resolve();
                } else {
                    reject();
                }
            })
            .catch(err => {
                console.log(err);
                reject();
            });
    });
};

export const getUserInfo = () => {
    return new Promise(function(resolve, reject) {
        http.get("api/auth/identity")
            .then(result => {
                if (result.data) {
                    store.dispatch("updateUserInfo", { data: result.data });
                    resolve(result.data);
                } else {
                    reject();
                }
            })
            .catch(err => {
                console.log(err);
                reject();
            });
    });
};
