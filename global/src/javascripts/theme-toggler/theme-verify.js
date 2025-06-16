    try {
      const theme = localStorage.getItem('theme') || 'light-theme';
      document.documentElement.classList.add(theme);
    } catch (e) {}