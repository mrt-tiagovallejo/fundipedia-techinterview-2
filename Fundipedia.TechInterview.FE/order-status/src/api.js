import axios from "axios";

const API_BASE_URL = "https://localhost:7198/api";

export const OrderApi = {
  sendRequest: (orderRequest) => axios.post(`${API_BASE_URL}/orders/status`, orderRequest),
};