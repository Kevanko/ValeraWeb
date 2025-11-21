import React, { useState, useEffect } from 'react';
import {
  Container,
  TextField,
  Button,
  Card,
  CardContent,
  Typography,
  Grid,
  Box,
  CircularProgress,
  Alert
} from '@mui/material';

import { getValeras, createValera } from '../services/api';

export default function ValeraList() {
  const [valeras, setValeras] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [isCreating, setIsCreating] = useState(false);
  const [formData, setFormData] = useState({
    name: 'Новый Валера',
    health: 100,
    alcohol: 0,
    joy: 0,
    fatigue: 0,
    money: 0
  });
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Загружаем список Валер при старте
  useEffect(() => {
    loadValeras();
  }, []);

  const loadValeras = async () => {
    try {
      setLoading(true);
      setError(null);
      const response = await getValeras();
      setValeras(response.data);
    } catch (err) {
      setError('Не удалось загрузить Валер. Убедитесь, что backend запущен.');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  const handleCreate = async () => {
    try {
      await createValera(formData);
      await loadValeras(); // обновляем список
      setFormData({ name: '', health: 100, alcohol: 0, joy: 0, fatigue: 0, money: 0 });
      setIsCreating(false);
    } catch (err) {
      alert('Ошибка при создании Валеры');
      console.error(err);
    }
  };

  const filteredValeras = valeras.filter(valera =>
    valera.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <Container maxWidth="md" sx={{ py: 4 }}>
      <Typography variant="h3" gutterBottom align="center">
        Список Валер
      </Typography>

      {error && <Alert severity="error" sx={{ mb: 2 }}>{error}</Alert>}

      {/* Поиск */}
      <TextField
        fullWidth
        label="Поиск по имени"
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
        sx={{ mb: 3 }}
      />

      {/* Кнопка создания */}
      <Box sx={{ display: 'flex', justifyContent: 'center', mb: 3 }}>
        <Button
          variant="contained"
          color="primary"
          onClick={() => setIsCreating(!isCreating)}
        >
          {isCreating ? 'Отменить' : 'Создать Валеру'}
        </Button>
      </Box>

      {/* Форма создания */}
      {isCreating && (
        <Card sx={{ mb: 4, p: 2 }}>
          <Typography variant="h6" gutterBottom>Создать нового Валеру</Typography>
          <Grid container spacing={2}>
            <Grid item xs={12}>
              <TextField
                fullWidth
                label="Имя"
                value={formData.name}
                onChange={(e) => setFormData({ ...formData, name: e.target.value })}
              />
            </Grid>
            <Grid item xs={6}>
              <TextField
                type="number"
                label="Здоровье"
                value={formData.health}
                onChange={(e) => setFormData({ ...formData, health: Number(e.target.value) })}
                inputProps={{ min: 0, max: 100 }}
              />
            </Grid>
            <Grid item xs={6}>
              <TextField
                type="number"
                label="Алкоголь"
                value={formData.alcohol}
                onChange={(e) => setFormData({ ...formData, alcohol: Number(e.target.value) })}
                inputProps={{ min: 0, max: 100 }}
              />
            </Grid>
            <Grid item xs={6}>
              <TextField
                type="number"
                label="Жизнерадостность"
                value={formData.joy}
                onChange={(e) => setFormData({ ...formData, joy: Number(e.target.value) })}
                inputProps={{ min: -10, max: 10 }}
              />
            </Grid>
            <Grid item xs={6}>
              <TextField
                type="number"
                label="Усталость"
                value={formData.fatigue}
                onChange={(e) => setFormData({ ...formData, fatigue: Number(e.target.value) })}
                inputProps={{ min: 0, max: 100 }}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                type="number"
                label="Деньги"
                value={formData.money}
                onChange={(e) => setFormData({ ...formData, money: Number(e.target.value) })}
              />
            </Grid>
            <Grid item xs={12}>
              <Button
                variant="contained"
                color="success"
                fullWidth
                onClick={handleCreate}
              >
                Создать
              </Button>
            </Grid>
          </Grid>
        </Card>
      )}

      {/* Индикатор загрузки */}
      {loading && (
        <Box sx={{ display: 'flex', justifyContent: 'center', my: 4 }}>
          <CircularProgress />
        </Box>
      )}

      {/* Список Валер */}
      <Grid container spacing={2}>
        {filteredValeras.map((valera) => (
          <Grid item xs={12} sm={6} md={4} key={valera.id}>
            <Card
              sx={{ cursor: 'pointer', '&:hover': { boxShadow: 6 } }}
              onClick={() => window.location.href = `/valera/${valera.id}`}
            >
              <CardContent>
                <Typography variant="h6">{valera.name}</Typography>
                <Box sx={{ mt: 1 }}>
                  <Typography>💰 Деньги: ${valera.money}</Typography>
                  <Typography>❤️ Здоровье: {valera.health}</Typography>
                  <Typography>🍷 Алкоголь: {valera.alcohol}</Typography>
                </Box>
              </CardContent>
            </Card>
          </Grid>
        ))}
      </Grid>

      {filteredValeras.length === 0 && !loading && (
        <Typography align="center" sx={{ mt: 4, color: 'text.secondary' }}>
          {valeras.length === 0 
            ? 'Нет Валер. Создайте первого!' 
            : 'Ничего не найдено'}
        </Typography>
      )}
    </Container>
  );
}