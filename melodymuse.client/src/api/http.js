import axios from "axios";
import router from "../router"; // 导入你的 Vue Router 实例

// 创建一个 axios 实例
const apiClient = axios.create({
  //baseURL: "https://localhost:7223", //调试
  baseURL: "http://api.tongji.store", // 线上
  // baseURL: "http://localhost:5000", // 本地
  timeout: 100000,
});

// 请求拦截器
apiClient.interceptors.request.use(
  (config) => {
    //那这里是不是就不能强行带token了，可以设置参数
    const { auth = true } = config.query || config.data || {};
    if (auth) {
      const token = localStorage.getItem("token"); // 假设你的 token 存储在 localStorage 中
      console.log(token)
      if (!token) {
        console.log(config)
        // 如果没有 token，跳转到登录页面
        alert("请先登录！");
        router.push("/login"); // 替换为你的登录页面路径
        return Promise.reject(new Error("No token, redirecting to login."));
      }

      config.headers.Authorization = `Bearer ${token}`;
    }

    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

// 响应拦截器
apiClient.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (error.response && error.response.status === 401) {
      // 如果返回的状态码是 401，使用路由器跳转到登录页面
      alert("登录状态失效！");
      router.push("/login"); // 替换为你的登录页面路径
    }
    return Promise.reject(error);
  }
);

export default { apiClient };
