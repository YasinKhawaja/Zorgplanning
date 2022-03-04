import { Box, TextField } from "@mui/material";
import { useState } from "react";
import { useHistory } from "react-router-dom";

export default function TeamForm() {
  const [name, setName] = useState("");
  const [isPending, setIsPending] = useState(false);
  const history = useHistory();

  const handleChange = (event) => {
    setName(event.target.value);
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    const team = { id: 0, name };

    fetch("api/teams", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(team),
    }).then(() => {
      setIsPending(false);
      window.location.reload();
    });
  };

  return (
    <Box
      component="form"
      sx={{
        "& .MuiTextField-root": { marginTop: 1, width: "25ch" },
      }}
      noValidate
      autoComplete="off"
      onSubmit={handleSubmit}
    >
      <div>
        <TextField
          id="name"
          label="Name"
          value={name}
          onChange={handleChange}
          required
        />
      </div>
    </Box>
  );
}
