import CalendarMonthOutlinedIcon from "@mui/icons-material/CalendarMonthOutlined";
import React from "react";
import { NavLink } from "react-router-dom";
import { SignOutButton } from "../authentication/SignOutButton";

export default function Header() {
  return (
    <div className="fixed-top" style={{ backgroundColor: "#F4F5FD" }}>
      <header className="container d-flex flex-wrap align-items-center justify-content-center justify-content-md-between py-3 mb-4 border-bottom">
        <NavLink
          to="/"
          className="d-flex align-items-center col-md-3 mb-2 mb-md-0 text-dark text-decoration-none"
        >
          <CalendarMonthOutlinedIcon color="primary" fontSize="large" />
          CP
        </NavLink>
        <ul className="nav col-12 col-md-auto mb-2 justify-content-center mb-md-0">
          <li>
            <NavLink to="/dashboard" className="nav-link px-2 link-secondary">
              Dashboard
            </NavLink>
          </li>
          <li>
            <NavLink
              to="/holidays"
              className={(isActive) =>
                "nav-link px-2 link-dark" + (!isActive ? " unselected" : "")
              }
              style={(isActive) => ({
                color: isActive ? "blue" : "",
              })}
            >
              Holidays
            </NavLink>
          </li>
          <li>
            <NavLink
              to="/teams"
              className={(isActive) =>
                "nav-link px-2 link-dark" + (!isActive ? " unselected" : "")
              }
              style={(isActive) => ({
                color: isActive ? "blue" : "",
              })}
            >
              Teams
            </NavLink>
          </li>
          <li>
            <NavLink
              to="/planning"
              className={(isActive) =>
                "nav-link px-2 link-dark" + (!isActive ? " unselected" : "")
              }
              style={(isActive) => ({
                color: isActive ? "blue" : "",
              })}
            >
              Planning
            </NavLink>
          </li>
        </ul>
        <div className="col-md-3 text-end">
          <SignOutButton />
        </div>
      </header>
    </div>
  );
}
