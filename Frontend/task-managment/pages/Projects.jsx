import React, { useState, useEffect } from "react";
import axios from "axios";
import { Box, Container, Stack, Text, Heading, Button, Spinner } from "@chakra-ui/react";

const Projects = () => {
  const [projects, setProjects] = useState([]); 
  const [loading, setLoading] = useState(true); 
  const [error, setError] = useState(null); 
  const [expandedTaskId, setExpandedTaskId] = useState(null); 

  // Метод для загрузки данных из API
  const fetchProjects = async () => {
    try {
      const response = await axios.get("https://localhost:7008/api/project", {withCredentials: true}); 
      setProjects(response.data); 
    } catch (err) {
      setError(err.response?.data?.message || err.message); 
    } finally {
      setLoading(false); 
    }
  };

  // Вызов fetchProjects при монтировании компонента
  useEffect(() => {
    fetchProjects();
  }, []);

  const toggleTask = (taskId) => {
    setExpandedTaskId(expandedTaskId === taskId ? null : taskId);
  };

  // Если идет загрузка, показываем индикатор
  if (loading) {
    return (
      <Container maxW="lg" mt="8" textAlign="center">
        <Spinner size="xl" />
        <Text mt="4">Загрузка задач...</Text>
      </Container>
    );
  }

  
  if (error) {
    return (
      <Container maxW="lg" mt="8" textAlign="center">
        <Text color="red.500" fontWeight="bold">
          Ошибка: {error}
        </Text>
      </Container>
    );
  }

  // Основной рендер компонентов
  return (
    <Container maxW="lg" mt="8">
      <Heading
        size="lg"
        mb="6"
        textAlign="center"
        bgGradient="linear(to-r, purple.500, blue.500)"
        bgClip="text"
      >
        Список задач
      </Heading>
      <Stack spacing="6">
        {projects.map((project) => (
          <Box
            key={project.id}
            p="6"
            borderRadius="lg"
            boxShadow="lg"
            bg="white"
            _hover={{ bg: "gray.50", transform: "scale(1.02)" }}
            transition="all 0.2s"
          >
            <Heading size="md" mb="3" color="purple.600">
              {project.title}
            </Heading>
            <Button
              size="sm"
              onClick={() => toggleTask(project.id)}
              bg="purple.500"
              color="white"
              _hover={{ bg: "purple.600" }}
              _active={{ bg: "purple.700" }}
            >
              {expandedTaskId === project.id ? "Скрыть" : "Развернуть"}
            </Button>
            {expandedTaskId === project.id && (
              <Text mt="4" color="gray.700">
                {project.description}
              </Text>
            )}
          </Box>
        ))}
      </Stack>
    </Container>
  );
};

export default Projects;
