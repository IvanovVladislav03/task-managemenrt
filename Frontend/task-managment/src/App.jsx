import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Registration from "../pages/Registration";
import Login from "../pages/Login";
import Projects from "../pages/Projects";
import Admin from "../pages/Admin";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/register" element={<Registration />} />
        <Route path="/login" element={<Login />} />
        <Route path="/projects" element={<Projects />} />
        <Route path="/admin" element={<Admin />} />
      </Routes>
    </Router>
  );
}

export default App;
