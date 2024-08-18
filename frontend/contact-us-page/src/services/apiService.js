import axios from 'axios';

const API_BASE_URL = 'http://localhost:5160/api';

export const getContactInfo = () => {
    return axios.get(`${API_BASE_URL}/Contact/contactinfo`);
};

export const submitForm = (formData) => {
    return axios.post(`${API_BASE_URL}/Contact/submitform`, formData);
};
