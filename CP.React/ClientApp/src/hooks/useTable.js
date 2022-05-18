import {
  Table,
  TableCell,
  TableHead,
  TablePagination,
  TableRow,
} from "@mui/material";
import React from "react";

export function useTable(headers, rows) {
  const TableContainer = (props) => {
    return (
      <TableContainer>
        <Table className="table table-hover">{props.children}</Table>
      </TableContainer>
    );
  };

  const TableHeader = () => {
    return (
      <TableHead>
        <TableRow>
          {headers.map((header) => (
            <TableCell key={header.id} sx={{ textAlign: "center" }}>
              {header.label}
            </TableCell>
          ))}
        </TableRow>
      </TableHead>
    );
  };

  const pages = [5, 10, 25];
  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(pages[page]);

  const handlePageChange = (event, newPage) => {
    setPage(newPage);
  };

  const handleRowsPerPageChange = (event) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  const TablePaginator = () => (
    <TablePagination
      component="div"
      count={rows.length}
      page={page}
      rowsPerPage={rowsPerPage}
      rowsPerPageOptions={pages}
      onPageChange={handlePageChange}
      onRowsPerPageChange={handleRowsPerPageChange}
    ></TablePagination>
  );

  return {
    TableContainer,
    TableHeader,
    TablePaginator,
  };
}
