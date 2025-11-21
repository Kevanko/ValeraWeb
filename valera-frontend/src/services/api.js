import axios from 'axios';

const API = axios.create({
  baseURL: '/api',
});

export const getValeras = () => API.get('/valera');
export const createValera = (data) => API.post('/valera', data);
export const getValeraById = (id) => API.get(`/valera/${id}`);
export const performAction = (id, action) => API.post(`/valera/${id}/${action}`);