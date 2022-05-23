import CalendarMonthIcon from "@mui/icons-material/CalendarMonth";
import MenuIcon from "@mui/icons-material/Menu";
import {
  AppBar,
  Box,
  Button,
  Container,
  IconButton,
  Menu,
  MenuItem,
  Toolbar,
  Typography,
} from "@mui/material";
import React from "react";
import { NavLink } from "react-router-dom";

const pages = [
  { to: "/holidays", text: "Feestdagen" },
  { to: "/teams", text: "Teams" },
  { to: "/planning", text: "Planning" },
];

export default function Header() {
  const [anchorElNav, setAnchorElNav] = React.useState(null);

  const handleOpenNavMenu = (event) => {
    setAnchorElNav(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  return (
    <AppBar position="fixed" sx={{ boxShadow: "0" }}>
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <Logo />
          <Box sx={{ flexGrow: 1, display: { xs: "flex", md: "none" } }}>
            <IconButton
              size="large"
              aria-label="account of current user"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleOpenNavMenu}
              color="inherit"
            >
              <MenuIcon />
            </IconButton>
            <Menu
              id="menu-appbar"
              anchorEl={anchorElNav}
              anchorOrigin={{
                vertical: "bottom",
                horizontal: "left",
              }}
              keepMounted
              transformOrigin={{
                vertical: "top",
                horizontal: "left",
              }}
              open={Boolean(anchorElNav)}
              onClose={handleCloseNavMenu}
              sx={{
                display: { xs: "block", md: "none" },
              }}
            >
              {pages.map((page, i) => (
                <MenuItemLinkButton
                  key={i}
                  page={page}
                  onCloseNavMenu={handleCloseNavMenu}
                />
              ))}
            </Menu>
          </Box>
          <LogoResponsive />
          <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
            {pages.map((page, i) => (
              <NavLinkButton
                key={i}
                page={page}
                onCloseNavMenu={handleCloseNavMenu}
              />
            ))}
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
}

function NavLinkButton(props) {
  return (
    <NavLink
      to={props.page.to}
      style={{ textDecoration: "none", color: "inherit" }}
    >
      <Button
        disableRipple
        onClick={props.onCloseNavMenu}
        sx={{ my: 2, color: "white", display: "block" }}
      >
        {props.page.text}
      </Button>
    </NavLink>
  );
}

function MenuItemLinkButton(props) {
  return (
    <NavLink
      to={props.page.to}
      style={{ textDecoration: "none", color: "inherit" }}
    >
      <MenuItem onClick={props.onCloseNavMenu}>
        <Typography textAlign="center">{props.page.text}</Typography>
      </MenuItem>
    </NavLink>
  );
}

function Logo() {
  return (
    <>
      <NavLink to="/" style={{ textDecoration: "none", color: "inherit" }}>
        <CalendarMonthIcon
          sx={{ display: { xs: "none", md: "flex" }, mr: 1 }}
        />
      </NavLink>
      <Typography
        variant="h6"
        noWrap
        sx={{
          mr: 2,
          display: { xs: "none", md: "flex" },
          fontFamily: "monospace",
          fontWeight: 700,
          letterSpacing: ".3rem",
          color: "inherit",
          textDecoration: "none",
        }}
      >
        <NavLink to="/" style={{ textDecoration: "none", color: "inherit" }}>
          CP
        </NavLink>
      </Typography>
    </>
  );
}

function LogoResponsive() {
  return (
    <>
      <NavLink
        to="/"
        style={{
          textDecoration: "none",
          color: "inherit",
        }}
      >
        <CalendarMonthIcon
          sx={{ display: { xs: "flex", md: "none" }, mr: 1 }}
        />
      </NavLink>
      <Typography
        variant="h5"
        noWrap
        sx={{
          mr: 2,
          display: { xs: "flex", md: "none" },
          flexGrow: 1,
          fontFamily: "monospace",
          fontWeight: 700,
          letterSpacing: ".3rem",
          color: "inherit",
          textDecoration: "none",
        }}
      >
        <NavLink to="/" style={{ textDecoration: "none", color: "inherit" }}>
          CP
        </NavLink>
      </Typography>
    </>
  );
}
