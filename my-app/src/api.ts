import axios from 'axios';

const API_URL = "http://localhost:5000/api"; // Update with your backend URL

export const login = async (email: string, password: string) => {
    const response = await axios.post(`${API_URL}/auth/login`, { email, password });
    return response.data;
};

export const getTasks = async (token: string) => {
    const response = await axios.get(`${API_URL}/tasks`, {
        headers: { Authorization: `Bearer ${token}` }
    });
    return response.data;
};
    