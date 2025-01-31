<template>
  <div class="app">
    <h1>Order Status Request</h1>
    <form @submit.prevent="submitOrder">
      <div>
        <label>
          <input type="checkbox" v-model="orderRequest.isRushOrder" />
          Is Rush Order
        </label>
      </div>

      <div>
        <label>Order Type:</label>
        <select v-model="orderRequest.orderType">
          <option value="Repair">Repair</option>
          <option value="Hire">Hire</option>
        </select>
      </div>

      <div>
        <label>
          <input type="checkbox" v-model="orderRequest.isNewCustomer" />
          Is New Customer
        </label>
      </div>

      <div>
        <label>
          <input type="checkbox" v-model="orderRequest.isLargeOrder" />
          Is Large Order
        </label>
      </div>
      
      <button type="submit">Check Status</button>
    </form>

    <div v-if="orderStatus" class="result">
      <h2>Order Status: {{ orderStatus }}</h2>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      orderRequest: {
        isRushOrder: false,
        orderType: "Repair",
        isNewCustomer: false,
        isLargeOrder: false,
      },
      orderStatus: null,
    };
  },
  methods: {
    async submitOrder() {
      try {
        const response = await axios.post("https://localhost:7198/api/orders/status", this.orderRequest);
        this.orderStatus = response.data;
      } catch (error) {
        console.error("Error checking order status:", error);
        alert("Failed to check order status. Please try again.");
      }
    },
  },
};
</script>

<style>
.app {
  font-family: Arial, sans-serif;
  margin: 20px;
}

form {
  margin-bottom: 20px;
}

.result {
  margin-top: 20px;
  padding: 10px;
  border: 1px solid #ccc;
  background-color: #f9f9f9;
}
</style>