import axios from 'axios';

const API = axios.create({
  baseURL: '/api',
});

const getAuthHeader = () => {
  const token = localStorage.getItem('token');
  return token ? { Authorization: `Bearer ${token}` } : {};
};

export const register = (data) => API.post('/auth/register', data);
export const login = (credentials) => API.post('/auth/login', credentials);

export const getValeras = () => API.get('/valera', { headers: getAuthHeader() });
export const getValeraById = (id) => API.get(`/valera/${id}`, { headers: getAuthHeader() });
export const createValera = (data) => API.post('/valera', data, { headers: getAuthHeader() });
export const performAction = (id, action) => 
  API.post(`/valera/${id}/${action}`, {}, { headers: getAuthHeader() });