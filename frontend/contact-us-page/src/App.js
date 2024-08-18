import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import ContactUsPage from './pages/ContactUsPage';
import ThankYouPage from './pages/ThankYouPage';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/thank-you" element={<ThankYouPage />} />
                <Route path="/" element={<ContactUsPage />} />
            </Routes>
        </Router>
    );
}

export default App;
