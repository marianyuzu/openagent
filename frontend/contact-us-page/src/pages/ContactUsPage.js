import React, { useState, useEffect } from 'react';
import { getContactInfo, submitForm } from '../services/apiService';
import './ContactUsPage.css';

function ContactUsPage() {
    const [contactInfo, setContactInfo] = useState({
        header: 'Contact us, we love to hear from you',
        body: "Welcome to OpenAgent. We've been around since 2013, and our vision is to make it easy for people to buy, sell and own property. Here are the different ways you can contact us",
        phone: 'Loading...',
        email: 'Loading...',
        address: 'Loading...',
        hours: 'Loading...'
    });

    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        email: '',
        phone: '',
        message: ''
    });

    useEffect(() => {
        getContactInfo()
            .then(response => setContactInfo(response.data))
            .catch(error => console.error('Error fetching contact info:', error));
    }, []);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        submitForm(formData)
            .then((response) => {
                if (response.status === 200) {
                    window.location.href = '/thank-you';
                }
            })
            .catch(error => {
                console.error('Error submitting form:', error);
                alert('There was an error submitting the form. Please try again.');
            });
    };

    return (
        <div className="contact-us-page">
            <div className="contact-info">
                <h1>{contactInfo.header}</h1>
                <p>{contactInfo.body}</p>
                <div>
                    <p><strong>Contact Us Details</strong></p>
                    <p>Phone: {contactInfo.phone}</p>
                    <p>Email: {contactInfo.email}</p>
                </div>
                <div>
                    <p><strong>Postal Address:</strong></p>
                    <p>{contactInfo.address}</p>
                </div>
                <div>
                    <p><strong>Contact centre hours of operation</strong></p>
                    <p>{contactInfo.hours}</p>
                </div>
            </div>
            <div className="contact-form">
                <h2>Fill in your details and we’ll be in touch right away. Or if you prefer, call us on {contactInfo.phone}</h2>
                <form onSubmit={handleSubmit}>
                    <input
                        type="text"
                        name="firstName"
                        placeholder="First name"
                        value={formData.firstName}
                        onChange={handleChange}
                        required
                    />
                    <input
                        type="text"
                        name="lastName"
                        placeholder="Last name"
                        value={formData.lastName}
                        onChange={handleChange}
                        required
                    />
                    <input
                        type="email"
                        name="email"
                        placeholder="Email address"
                        value={formData.email}
                        onChange={handleChange}
                        required
                    />
                    <input
                        type="text"
                        name="phone"
                        placeholder="Phone number"
                        value={formData.phone}
                        onChange={handleChange}
                    />
                    <textarea
                        name="message"
                        placeholder="What do you want to speak to us about"
                        value={formData.message}
                        onChange={handleChange}
                        required
                    />
                    <button type="submit">SEND MESSAGE</button>
                </form>
                <p className="terms">
                    By sending a message you agree to the <a href="#">Terms and Conditions</a> and <a href="#">Privacy Policy</a>.
                </p>
            </div>
        </div>
    );
}

export default ContactUsPage;
