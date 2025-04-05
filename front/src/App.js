// src/App.js 
import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Sidebar from './components/Sidebar';
import MyNavbar from './components/Navbar';
import BreadcrumbContent from './components/BreadcrumbContent';
import HomePage from './pages/HomePage';  
import NuevaCulture from './pages/NuevaCulture';
import TablaCultures from './pages/TablaCultures';
import { Container } from 'reactstrap';

const App = () => {
  const [sidebarExpanded, setSidebarExpanded] = useState(true);
  
  // Función para comunicar el estado del sidebar
  const handleSidebarToggle = (isExpanded) => {
    setSidebarExpanded(isExpanded);
  };

  return (
    <Router>
      <div className="d-flex">
        <Sidebar onToggle={handleSidebarToggle} />
        <div className="content-wrapper" style={{ 
          marginLeft: sidebarExpanded ? '250px' : '70px', 
          width: `calc(100% - ${sidebarExpanded ? '250px' : '70px'})`,
          transition: 'margin-left 0.3s, width 0.3s',
          minHeight: '100vh' 
        }}>
          <MyNavbar />
          <Container fluid className="p-4">
            {/* Breadcrumbs colocados en el área de contenido */}
            <BreadcrumbContent />
            
            <Routes>
              <Route exact path="/" element={<HomePage />} />
              <Route path="/crear_culture" element={<NuevaCulture />} />
              <Route path="/tabla_cultures" element={<TablaCultures />} />
            </Routes>
          </Container>
        </div>
      </div>
    </Router>
  );
};

export default App;