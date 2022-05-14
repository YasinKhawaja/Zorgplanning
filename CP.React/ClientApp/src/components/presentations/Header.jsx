import CalendarMonthOutlinedIcon from "@mui/icons-material/CalendarMonthOutlined";
import CelebrationIcon from "@mui/icons-material/Celebration";
import DashboardIcon from "@mui/icons-material/Dashboard";
import GroupsIcon from "@mui/icons-material/Groups";
import TableViewIcon from "@mui/icons-material/TableView";
import { Button } from "@mui/material";
import React from "react";
import { NavLink } from "react-router-dom";

function NavLinkButton(props) {
  return (
    <Button
      color="inherit"
      component="div"
      disableRipple
      startIcon={props.startIcon}
    >
      {props.text}
    </Button>
  );
}

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
              <NavLinkButton text="Dashboard" startIcon={<DashboardIcon />} />
            </NavLink>
          </li>
          <li>
            <NavLink
              to="/holidays"
              className={(isActive) =>
                "nav-link px-2 link-dark" + (!isActive ? " unselected" : "")
              }
              style={(isActive) => ({
                color: isActive ? "#0288D1" : "",
              })}
            >
              <NavLinkButton
                text="Feestdagen"
                startIcon={<CelebrationIcon />}
              />
            </NavLink>
          </li>
          <li>
            <NavLink
              to="/teams"
              className={(isActive) =>
                "nav-link px-2 link-dark" + (!isActive ? " unselected" : "")
              }
              style={(isActive) => ({
                color: isActive ? "#0288D1" : "",
              })}
            >
              <NavLinkButton text="Teams" startIcon={<GroupsIcon />} />
            </NavLink>
          </li>
          <li>
            <NavLink
              to="/planning"
              className={(isActive) =>
                "nav-link px-2 link-dark" + (!isActive ? " unselected" : "")
              }
              style={(isActive) => ({
                color: isActive ? "#0288D1" : "",
              })}
            >
              <NavLinkButton text="Planning" startIcon={<TableViewIcon />} />
            </NavLink>
          </li>
        </ul>
        <div className="col-md-3 text-end">{/* <SignOutButton /> */}</div>
      </header>
    </div>
  );
}
