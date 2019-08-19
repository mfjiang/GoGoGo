import Axios from "axios";
import qs from "qs";
import { getToken } from "./index";

// Axios.defaults.headers["Content-Type"] = "application/x-www-form-urlencoded;charset=UTF-8";
//axios.defaults.headers["Authorization"] = getAccessToken();
Axios.defaults.timeout = 30000; // 30s
Axios.defaults.withCredentials = true;

/**
 *
 */
class HttpClient {
    constructor() {}

    config() {
        return {
            baseURL: "/",
            headers: {
                //
                Authorization: "Bearer " + getToken()
            }
        };
    }

    interceptors(instance, options) {}

    create(options) {
        var instance = Axios.create();
        options = Object.assign(this.config(), options);

        this.interceptors(instance, options);
        return instance(options);
    }
}

const http = new HttpClient();

const get = (url, params) => {
    return http.create({
        url: url,
        params
    });
};

const post = (url, data) => {
    return http.create({
        method: "post",
        url: url,
        data: data
    });
};

export default {
    get,
    post
};
